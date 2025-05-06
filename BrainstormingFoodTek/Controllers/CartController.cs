using BrainstormingFoodTek.DTOs.CartDTOs.Request;
using BrainstormingFoodTek.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cartService;

        public CartController(ICart cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem([FromBody] CartRequestDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _cartService.AddItemToCart(itemDTO);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            return Ok(result);
        }
    }
}
