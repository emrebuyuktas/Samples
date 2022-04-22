using CqrsMediatr.Application.Dto;
using CqrsMediatr.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }
    }
}
