using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Wrappers
{
    public class PageResponse<T> : ServiceResponse<T>
    {
        public int PagaNumber { get; set; }
        public int PageSize { get; set; }

        public PageResponse(T value) : base(value)
        {

        }
        public PageResponse()
        {
            PagaNumber = 1;
            PageSize = 10;
        }
        public PageResponse(int pageNumber, int pageSize)
        {
            PagaNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
