using AutoMapper;
using Carting.Domain.Entities;
using Catalog.Application.Interfaces;
using Catalog.DataAccessLayer;
using Catalog.DataAccessLayer.Entities;

namespace Catalog.Application.Services
{
    public class CategoryService : ICategoriesService
    {
        private readonly IRepository<CategoryDALEntity> _categoryDALEntityRepository;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<CategoryDALEntity> categoryDALEntityRepository, IMapper mapper) 
        {
            _categoryDALEntityRepository = categoryDALEntityRepository;
            _mapper = mapper;
        }
        public async Task Delete(int categoryId)
        {
            var categoryDAL = await _categoryDALEntityRepository.Get(categoryId);
            await _categoryDALEntityRepository.Delete(categoryDAL);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categoryDALs = await _categoryDALEntityRepository.GetAll();
            var categories = categoryDALs.Select(dal => _mapper.Map<Category>(dal));
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var categoryDALEntity = await _categoryDALEntityRepository.Get(id);
            var categories = _mapper.Map<Category>(categoryDALEntity);
            return categories;
        }

        public async Task Post(Category category)
        {
            var categoryDAL = _mapper.Map<CategoryDALEntity>(category);
            await _categoryDALEntityRepository.Post(categoryDAL);
        }

        public async Task Put(Category category)
        {
            var categoryDAL = _mapper.Map<CategoryDALEntity>(category);
            await _categoryDALEntityRepository.Put(categoryDAL);
        }
    }
}
