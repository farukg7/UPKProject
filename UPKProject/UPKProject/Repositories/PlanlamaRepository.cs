using Entities.Models;
using Entities.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UretimPlanlamaKontrol.Repositories;

namespace Repositories
{
    public class PlanlamaRepository : RepositoryBase<Planlama>, IPlanlamaRepository
    {
        private readonly IUrunRepository _urunRepository;
        private readonly IHammaddeRepository _hammaddeRepository;
        private readonly IUrunSiparisRepository _urunSiparisRepository;
        private readonly IHammaddeSiparisRepository _hammaddeSiparisRepository;

        public PlanlamaRepository(RepositoryContext context, IUrunRepository urunRepository, IHammaddeRepository hammaddeRepository, IUrunSiparisRepository urunSiparisRepository, IHammaddeSiparisRepository hammaddeSiparisRepository) : base(context)
        {
            _urunRepository = urunRepository;
            _hammaddeRepository = hammaddeRepository;
            _urunSiparisRepository = urunSiparisRepository;
            _hammaddeSiparisRepository = hammaddeSiparisRepository;
        }

        public void CreatePlan(Planlama planlama)=>Create(planlama);

        public IQueryable<Planlama> GetAllPlanlama(bool trackChanges)
        {
            return trackChanges
                ? _context.Planlama.Include(u => u.Urun).Include(us => us.UrunSiparis).Include(r => r.Rotalar)
                : _context.Planlama.Include(u => u.Urun).Include(us => us.UrunSiparis).Include(r => r.Rotalar);
        }

        public List<PlanViewModel> GetAllSiparis()
        {
            var urunler = _urunRepository.GetAllUrunByNotNullUrunSiparis(false).GroupBy(u => u.UrunId).Select(g => g.First());

            List<PlanViewModel> planViewModels = new();

            int toplamEksikMiktar = 0;

            foreach (var urun in urunler)
            {
                var urunSiparis = _urunSiparisRepository.GetAllUrunSiparisByUrun(urun.UrunId, false).OrderBy(u=>u.UrunTeslimMiktari);
                var hammaddeler = _hammaddeRepository.GetAllHammaddelerByUrun(urun.UrunId, false);
                var hammaddeSiparis = _hammaddeSiparisRepository.GetAllHammaddeSiparislerByUrun(urun.UrunId, false).OrderBy(h=>h.HammaddeTeslimTarihi);
                var zamanindaMiktar = _hammaddeSiparisRepository.GetAllHammaddeSiparislerByUrunAndSiparisTarihi(urun.UrunId, false);

                PlanViewModel planViewModel = new();

                planViewModel.UrunAdi = urun.UrunAdi;

                int teslimEdilmeyenAdet = 0;

                foreach (var siparis in urunSiparis)
                {
                    planViewModel.UrunSiparisAdedi.Add((int)siparis.UrunSiparisAdedi);
                    planViewModel.UrunTeslimMiktari.Add((int)siparis.UrunTeslimMiktari);                  
                }

                teslimEdilmeyenAdet = (int)(planViewModel.UrunSiparisAdedi.Sum() - planViewModel.UrunTeslimMiktari.Sum());


                foreach (var hammadde in hammaddeler)
                {
                    planViewModel.HammaddeAdi.Add(hammadde.HammaddeAdi);
                    planViewModel.KullanimMiktari.Add((int)hammadde.KullanimMiktari);
                    planViewModel.HammaddeMiktari.Add((int)hammadde.HammaddeMiktari);
                    int mevcutHammaddeyeGoreGerekenMiktar = teslimEdilmeyenAdet * (int)hammadde.KullanimMiktari;                   

                    int toplamHammaddeSiparisMiktari = 0;

                    foreach (var hammaddeSip in hammaddeSiparis)
                    {
                        if (hammaddeSip.HammaddeId == hammadde.HammaddeId)
                        {
                            toplamHammaddeSiparisMiktari += (int)hammaddeSip.HammaddeSiparisAdedi;
                        }
                    }


                    int hammaddeZamanindaEksikTeslimMiktari = 0;

                    foreach (var urunSip in urunSiparis)
                    {                       
                        int guncelUrunSiparisAdedi = ((int)urunSip.UrunSiparisAdedi - (int)urunSip.UrunTeslimMiktari);
                        foreach (var hammaddeSip in hammaddeSiparis)
                        {
                            //if (hammaddeSip.HammaddeId == hammadde.HammaddeId)
                            //{
                                if (urunSip.UrunTeslimTarihi.Value.Date > hammaddeSip.HammaddeTeslimTarihi.Value.Date)
                                {
                                    hammaddeZamanindaEksikTeslimMiktari = guncelUrunSiparisAdedi - ((int)(hammaddeSip.HammaddeSiparisAdedi - hammaddeSip.HammaddeGelenAdet));
                                    if (hammaddeZamanindaEksikTeslimMiktari > 0)
                                    {
                                        guncelUrunSiparisAdedi = hammaddeZamanindaEksikTeslimMiktari;
                                        hammaddeSip.HammaddeSiparisAdedi = 0;
                                        hammaddeSip.HammaddeGelenAdet = 0;
                                    }
                                    else
                                    {
                                        hammaddeSip.HammaddeSiparisAdedi = Math.Abs(hammaddeZamanindaEksikTeslimMiktari);
                                    }
                                }
                                else
                                {
                                    if (hammaddeZamanindaEksikTeslimMiktari > 0)
                                    {
                                        toplamEksikMiktar += hammaddeZamanindaEksikTeslimMiktari * (int)hammadde.KullanimMiktari;
                                    }
                                    hammaddeZamanindaEksikTeslimMiktari = 0;
                                }
                            //}
                        }
                    }

                    planViewModel.HammaddeSiparisMiktari.Add(toplamHammaddeSiparisMiktari);

                    int kalanGerekenHammaddeMiktari = mevcutHammaddeyeGoreGerekenMiktar - (int)hammadde.HammaddeMiktari - toplamHammaddeSiparisMiktari;
                    if (toplamEksikMiktar > 0)
                    {
                        int zamanindaGelecekMiktar = mevcutHammaddeyeGoreGerekenMiktar - (int)hammadde.HammaddeMiktari - (mevcutHammaddeyeGoreGerekenMiktar - toplamEksikMiktar);
                        planViewModel.ToplamGerekenMiktar.Add(Math.Max(0, kalanGerekenHammaddeMiktari));
                        planViewModel.ZamanindaGelecekSiparisMiktari.Add(Math.Max(0, zamanindaGelecekMiktar));
                    }
                    else
                    {
                        int zamanindaGelecekMiktar = mevcutHammaddeyeGoreGerekenMiktar - (int)hammadde.HammaddeMiktari;
                        planViewModel.ToplamGerekenMiktar.Add(Math.Max(0, kalanGerekenHammaddeMiktari));
                        planViewModel.ZamanindaGelecekSiparisMiktari.Add(Math.Max(0, zamanindaGelecekMiktar));
                    }
                                                       
                    toplamEksikMiktar = 0;
                }

                
                
                //Dictionary<int, int> hammaddeSiparisDictionary = new Dictionary<int, int>();

                //foreach (var hammaddeSip in hammaddeSiparis)
                //{
                //    int hammaddeId = (int)hammaddeSip.HammaddeId;
                //    int siparisMiktari = (int)hammaddeSip.HammaddeSiparisAdedi;

                //    if (hammaddeSiparisDictionary.ContainsKey(hammaddeId))
                //    {
                //        hammaddeSiparisDictionary[hammaddeId] += siparisMiktari;
                //    }
                //    else
                //    {
                //        hammaddeSiparisDictionary[hammaddeId] = siparisMiktari;
                //    }
                //}

                //planViewModel.HammaddeSiparisMiktari = hammaddeSiparisDictionary.Values.ToList();
                /// bu yapı da doğruydu fakat 0 olan hammadde miktarlarını da alabilmek için yapıyı yukarda kurdum


                planViewModels.Add(planViewModel);
            }
            return planViewModels;
        }

        public Planlama? GetOnePlanlamaByUrunSiparisId(int id, bool trackChanges)
        {
            return FindbyCondition(p => p.UrunId == id, trackChanges);
        }

        public void UpdatePlan(Planlama planlama) => Update(planlama);
    }
}
