using AutoMapper;
using Carting.Domain.Entities;
using Catalog.Application.Interfaces;
using Catalog.DataAccessLayer;
using Catalog.DataAccessLayer.Entities;
using Catalog.Kafka.Client;
using Catalog.Kafka.Client.Interfaces;
using Catalog.Kafka.Client.Models;
using Catalog.Shared.Models;
using Confluent.Kafka;

namespace Catalog.Application.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IProducer<string, ItemUpdateEvent> _producer;
        private readonly IKafkaServices _kafkaService;
        private readonly string ItemTopicName = "ItemsUpdates";

        public ItemsService(IItemsRepository repository, IMapper mapper, IProducer<string, ItemUpdateEvent> producer, IKafkaServices kafkaService)
        {
            _repository = repository;
            _mapper = mapper;
            _producer = producer;
            _kafkaService = kafkaService;
        }
        public async Task Delete(int itemId)
        {
            var itemDAL = await _repository.Get(itemId);
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

        public async Task<List<Item>> GetItems(ItemsFilter itemsFilter)
        {
            var itemsDAL = await _repository.GetItems(itemsFilter);
            var items = itemsDAL.Select(dal => _mapper.Map<Item>(dal)).ToList();
            return items;
        }

        public async Task Post(Item item)
        {
            var itemDAL = _mapper.Map<ItemDALEntity>(item);    
            await _repository.Post(itemDAL);
        }

        public async Task Put(Item item)
        {
            var currentItem = await GetItem((int)item.Id);

            var itemDAL = _mapper.Map<ItemDALEntity>(item);
            await _repository.Put(itemDAL);
            await ProduceItemUpdateToKafka(currentItem, item);
        }

        private async Task ProduceItemUpdateToKafka(Item currentItem, Item item)
        {
            if (currentItem.Price != item.Price || currentItem.Name != item.Name)
            {
                var itemUpdateEvent = new ItemUpdateEvent((int)item.Id, item.Name, (double)item.Price);

                var message = new Message<string, ItemUpdateEvent>
                {
                    Key = item.Id.ToString(),
                    Value = itemUpdateEvent
                };

                _producer.Produce(ItemTopicName, message, (deliveryReport) =>
                {
                    _kafkaService.HandleDeliverReport(deliveryReport);
                });
            }
        }
    }
}
