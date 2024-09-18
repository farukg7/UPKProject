using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class HammaddeRequestParameters:RequestParameters
    {
        public int? KategoriId {  get; set; }
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set;}=int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public HammaddeRequestParameters():this(1,6)
        {
            
        }

        public HammaddeRequestParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


    }
}
