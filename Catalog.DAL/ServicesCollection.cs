using Catalog.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer
{
    public static class ServicesCollection
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IRepository<CategoryDALEntity>, Repository<CategoryDALEntity>>();
            services.AddScoped<IRepository<ItemDALEntity>, Repository<ItemDALEntity>>();
        }
    }
}
