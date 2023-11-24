using Carting.Domain.Entities;

namespace Catalog.Application.Interfaces
{
    public interface IItemsService
    {
        public Task<Item> GetItem(int id);
        public Task<List<Item>> GetAllItems();
        public Task Post(Item category);
        public Task Put(Item category);
        public Task Delete(Item category);

    }
}
