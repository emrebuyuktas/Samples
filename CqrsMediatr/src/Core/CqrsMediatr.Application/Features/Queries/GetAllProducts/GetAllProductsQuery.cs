using AutoMapper;
using CqrsMediatr.Application.Dto;
using CqrsMediatr.Application.Interfaces.Repositories;
using CqrsMediatr.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this._productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                //var dto= products.Select(x => new ProductViewDto()
                //{
                //    Id = x.Id,
                //    Name = x.Name
                //}).ToList();
                var dto = _mapper.Map<List<ProductViewDto>>(products);
                return new ServiceResponse<List<ProductViewDto>>(dto);
            }
        }
    }
}
