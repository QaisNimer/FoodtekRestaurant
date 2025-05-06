using BrainstormingFoodTek.DTOs.CategoryDTOs.Response;
using BrainstormingFoodTek.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _CategoryService;
        public CategoryController(ICategory CategoryService)
        {
            _CategoryService = CategoryService;
        }
        [HttpGet("Get-allCategories")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var categories = await _CategoryService.GetAllCategory();
            return Ok(categories);
        }
    }
}
