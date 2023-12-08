using Carting.Domain.Entities;
using Catalog.Shared.Models;

namespace Catalog.Application.Interfaces
{
    public interface IItemsService
    {
        public Task<Item> GetItem(int id);
        public Task<List<Item>> GetAllItems();
        public Task<List<Item>> GetItems(ItemsFilter itemsFilter);
        public Task Post(Item item);
        public Task Put(Item item);
        public Task Delete(int itemId);
    }
}
