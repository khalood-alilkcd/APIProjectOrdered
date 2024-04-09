using ApplicationProject.Dtos;
using AutoMapper;
using DomainCore.Models;


namespace OrderProductAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ProductForCreationDto, Product>().ForMember(p => p.ProductType.Name,
                p => p.MapFrom(s => s.ProductType))
                .ForMember(p => p.ProductBrand.Name,
                p => p.MapFrom(s => s.ProductBrand));
        }
    }
}
