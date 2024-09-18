using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AtolyeIslerManager : IAtolyeIslerService
    {
        private readonly IRepositoryManager _manager;

        public AtolyeIslerManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOneAtolyeIs(AtolyeIsler atolyeIs)
        {
            _manager.AtolyeIsler.CreateOneAtolyeIs(atolyeIs);
            _manager.Save();
        }

        public IEnumerable<AtolyeIsler> GetBoyaAtolye()
        {
            return _manager.AtolyeIsler.GetAllAtolyeIsler().Where(x => x.AtolyeId == 4).ToList();
        }

        public IEnumerable<AtolyeIsler> GetKablajAtolye()
        {
            return _manager.AtolyeIsler.GetAllAtolyeIsler().Where(x => x.AtolyeId == 3).ToList();
        }

        public IEnumerable<AtolyeIsler> GetMekanikAtolye()
        {
            return _manager.AtolyeIsler.GetAllAtolyeIsler().Where(x => x.AtolyeId == 1).ToList();
        }

        public IEnumerable<AtolyeIsler> GetMontajAtolye()
        {
            return _manager.AtolyeIsler.GetAllAtolyeIsler().Where(x => x.AtolyeId == 2).ToList();
        }

        public AtolyeIsler? GetOneAtolyeIslerByUrunIdAndAtolyeId(int uid, int aid, bool trackChanges)
        {
            return _manager.AtolyeIsler.GetOneAtolyeIslerByUrunIdAndAtolyeId(uid, aid, trackChanges);
        }

        public void UpdateOneAtolyeIs(AtolyeIsler atolyeIs)
        {
            _manager.AtolyeIsler.UpdateOneAtolyeIs(atolyeIs);
            _manager.Save();
        }
    }
}
