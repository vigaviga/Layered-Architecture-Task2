using Carting.Domain.Entities;
using Catalog.DataAccessLayer.Entities;
using Catalog.Shared.Models;

namespace Catalog.DataAccessLayer
{
    public interface IItemsRepository : IRepository<ItemDALEntity>
    {
        Task<List<ItemDALEntity>> GetItems(ItemsFilter itemsFilter);
    }
}
