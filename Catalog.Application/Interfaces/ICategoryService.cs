using Carting.Domain.Entities;

namespace Catalog.Application.Interfaces
{
    public interface ICategoriesService
    {
        public Task<Category> GetCategory(int id);
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task Post(Category category);
        public Task Put(Category category);
        public Task Delete(int categoryId);
    }
}
