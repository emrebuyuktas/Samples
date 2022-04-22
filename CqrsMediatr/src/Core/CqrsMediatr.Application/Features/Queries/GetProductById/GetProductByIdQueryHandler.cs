using AutoMapper;
using CqrsMediatr.Application.Dto;
using CqrsMediatr.Application.Interfaces.Repositories;
using CqrsMediatr.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductViewDto>(await _productRepository.GetByIdAsync(request.Id));
            return new ServiceResponse<ProductViewDto>(product);
        }
    }
}
