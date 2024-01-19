using AutoMapper;
using Carting.Domain.Entities;
using Catalog.Application.Interfaces;
using Catalog.Shared.Models;
using Layered_Architecture_Task2.Models;
using Layered_Architecture_Task2.RequestModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "ManagerOnly")]
        public async Task<IActionResult> Post(ItemAPIModel itemRequest)
        {
            var item = _mapper.Map<Item>(itemRequest);
            await _itemsService.Post(item);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await _itemsService.GetItem(id);
            if (item == null) return NotFound(id);
            return Ok(new ServiceResponse<Item>(item));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ItemsFilter itemFilters)
        {
            var categories = await _itemsService.GetItems(itemFilters);
            return Ok(categories);
        }

        [HttpPut]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<IActionResult> Put(ItemAPIModel itemRequest)
        {
            var item = _mapper.Map<Item>(itemRequest);
            await _itemsService.Put(item);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _itemsService.Delete(id);
            return Ok();
        }
    }
}
