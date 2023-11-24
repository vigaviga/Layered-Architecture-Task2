using AutoMapper;
using Carting.Domain.Entities;
using Catalog.Application.Interfaces;
using Layered_Architecture_Task2.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Layered_Architecture_Task2.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;
        private readonly IMapper _mapper;

        public ItemsController(IItemsService itemsService, IMapper mapper)
        {
            _itemsService = itemsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemAPIModel itemRequest)
        {
            var item = _mapper.Map<Item>(itemRequest);
            await _itemsService.Post(item);
            return Ok();
        }

        [HttpGet]
        [Route("Items/{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var category = await _itemsService.GetItem(id);
            if (category == null) return NotFound(id);
            return Ok(category);
        }

        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _itemsService.GetAllItems();
            return Ok(categories);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ItemAPIModel itemRequest)
        {
            var item = _mapper.Map<Item>(itemRequest);
            await _itemsService.Put(item);
            return Ok();
        }
    }
}
