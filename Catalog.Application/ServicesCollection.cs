using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application
{
    public static class ServicesCollection
    {
        public static void AddApplicationLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<ICategoriesService, CategoryService>();
            services.AddAutoMapper(typeof(RepoDomainMappingProfile));
        }
    }
}
