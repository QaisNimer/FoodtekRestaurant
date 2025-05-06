using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
       private readonly IItems _itemsService;
       private readonly IItems _getTopRecommendedItemService;
       private readonly IItems _getItemsByCategory;
       private readonly IItems _getFavItemById;
       public ItemsController(IItems getTopRatedItems,IItems getTopRecommendedItems,
           IItems getItemsByCategory, IItems getFavItemById)
       { 
            _itemsService = getTopRatedItems;
            _getTopRecommendedItemService = getTopRecommendedItems;
            _getItemsByCategory = getItemsByCategory;
            _getFavItemById = getFavItemById;
       }

        [HttpGet("top-rated-items")]
        public async Task<IActionResult> GetTopRatedItems()
        {
            var result = await _itemsService.GetTopRatedItems();
            return Ok(result);
        }

        [HttpGet("top-recommended-items")]
        public async Task<IActionResult> GetTopRecommendedItems()
        {
            var result = await _getTopRecommendedItemService.TopRecommendedItems();
            return Ok(result);
        }

        [HttpGet("items-by-category/{categoryId}")]
        public async Task<IActionResult> GetItemsByCategory([FromRoute]int categoryId)
        {
            var result = await _getItemsByCategory.GetItemByCategory(categoryId);
            return Ok(result);
        }

        [HttpGet("favorite-items-UserID/{userId}")]
        public async Task<IActionResult> GetFavoriteItemsByUserId([FromRoute] int userId)
        {
            var result = await _getFavItemById.GetFavoriteItemByUserId(userId);
            return Ok(result);
        }

        [HttpGet("Get-One-Item/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
                var existing = await _itemsService.GetOneItem(id);
                return Ok(existing);
        }

    }
}
