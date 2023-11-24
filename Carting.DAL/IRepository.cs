using Catalog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer
{
    public interface IRepository<TEntity>  where TEntity : BaseDALEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity?> Get(int id);
        Task Post(TEntity entity);
        Task Put(TEntity entity);
        Task Delete(TEntity id);
    }
}
