

using AutoMapper;
using CqrsMediatr.Application.Dto;
using CqrsMediatr.Application.Features.Commands.CreateProduct;
using CqrsMediatr.Domain.Entities;

namespace CqrsMediatr.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}
