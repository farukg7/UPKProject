using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IHammaddeService HammaddeService { get; }
        IKategoriService KategoriService { get; }
        IUrunService UrunService { get; }
        IProjeService ProjeService { get; }
        ISiparisService SiparisService { get; }
        IAuthService AuthService { get; }
        IHammaddeSiparisService HammaddeSiparisService { get;}
        IUrunSiparisService UrunSiparisService { get; }
        IAtolyeService AtolyeService { get; }
        IRotaService RotaService { get; }
        IAtolyeIslerService AtolyeIslerService { get; }
        IPlanlamaService PlanlamaService { get; }
        ITedarikciService TedarikciService { get; }
        IMusteriService MusteriService { get; }
    }
}
