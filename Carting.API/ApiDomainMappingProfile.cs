using AutoMapper;
using Carting.Domain.Entities;
using Layered_Architecture_Task2.RequestModels;

namespace Layered_Architecture_Task2
{
    public class ApiDomainMappingProfile : Profile
    {
        public ApiDomainMappingProfile() 
        {
            CreateMap<CategoryAPIModel, Category>();
                    
            CreateMap<Category, CategoryAPIModel>();

            CreateMap<Item,  ItemAPIModel>();

            CreateMap<ItemAPIModel, Item>();
        }
    }
}
