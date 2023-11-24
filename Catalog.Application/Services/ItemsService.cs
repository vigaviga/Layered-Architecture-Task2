using AutoMapper;
using Carting.Domain.Entities;
using Catalog.Application.Interfaces;
using Catalog.DataAccessLayer;
using Catalog.DataAccessLayer.Entities;

namespace Catalog.Application.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IRepository<ItemDALEntity> _repository;
        private readonly IMapper _mapper;
        public ItemsService(IRepository<ItemDALEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Delete(Item category)
        {
            var itemDAL = _mapper.Map<ItemDALEntity>(category);
            await _repository.Delete(itemDAL);
        }

        public async Task<List<Item>> GetAllItems()
        {
            var itemsDAL = await _repository.GetAll();
            var items = itemsDAL.Select(dal => _mapper.Map<Item>(dal)).ToList();
            return items;
        }

        public async Task<Item> GetItem(int id)
        {
            var itemDAL = await _repository.Get(id);
            return _mapper.Map<Item>(itemDAL);
        }

        public async Task Post(Item category)
        {
            var itemDAL = _mapper.Map<ItemDALEntity>(category);    
            await _repository.Post(itemDAL);
        }

        public async Task Put(Item category)
        {
            var itemDAL = _mapper.Map<ItemDALEntity>(category);
            await _repository.Put(itemDAL);
        }
    }
}
