using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Parameters
{
    public class RequestParameter
    {
        public int PageSize { get; set; }
        public int PagaNumber { get; set; }

        public RequestParameter(int pageSize, int pagaNumber)
        {
            PageSize = pageSize;
            PagaNumber = pagaNumber;
        }
    }
}
