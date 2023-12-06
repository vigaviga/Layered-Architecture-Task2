using AutoMapper;
using Carting.Domain.Entities;
using Catalog.Application.Interfaces;
using Layered_Architecture_Task2.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Layered_Architecture_Task2.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoriesService, IMapper mapper) 
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryAPIModel categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            await _categoriesService.Post(category);
            return Ok();
        }

        [HttpGet]
        [Route("Categories/{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var category = await _categoriesService.GetCategory(id);
            if (category == null) return NotFound(id);
            return Ok(category);
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> GetAll() 
        {
            var categories = await _categoriesService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryAPIModel categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            await _categoriesService.Put(category);
            return Ok();
        }
    }
}
