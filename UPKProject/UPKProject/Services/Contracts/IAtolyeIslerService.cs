using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAtolyeIslerService
    {
        void CreateOneAtolyeIs(AtolyeIsler atolyeIs);
        void UpdateOneAtolyeIs(AtolyeIsler atolyeIs);
        IEnumerable<AtolyeIsler> GetKablajAtolye();
        IEnumerable<AtolyeIsler> GetMontajAtolye();
        IEnumerable<AtolyeIsler> GetMekanikAtolye();
        IEnumerable<AtolyeIsler> GetBoyaAtolye();
        AtolyeIsler? GetOneAtolyeIslerByUrunIdAndAtolyeId(int uid, int aid, bool trackChanges);
    }
}
