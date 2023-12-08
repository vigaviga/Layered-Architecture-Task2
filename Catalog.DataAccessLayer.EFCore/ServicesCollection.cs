using Catalog.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer.EFCore
{
    public static class ServicesCollection
    {
        public static void AddEfCoreDAL(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IRepository<CategoryDALEntity>, Repository<CategoryDALEntity>>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
        }
    }
}
