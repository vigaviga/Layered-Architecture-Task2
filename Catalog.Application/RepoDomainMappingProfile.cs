using AutoMapper;
using Carting.Domain.Entities;
using Catalog.DataAccessLayer.Entities;

namespace Catalog.Application
{
    public class RepoDomainMappingProfile : Profile
    {
        //test change 
        public RepoDomainMappingProfile()
        {
            CreateMap<CategoryDALEntity, Category>();
            CreateMap<Category, CategoryDALEntity>();
            CreateMap<ItemDALEntity, Item>()
                    .ForMember(i => i.CategoryId, opt => opt.MapFrom(d => d.CategoryDALEntityId));
            CreateMap<Item, ItemDALEntity>()
                    .ForMember(d => d.CategoryDALEntityId, opt => opt.MapFrom(i => i.CategoryId));
        }
    }
}
