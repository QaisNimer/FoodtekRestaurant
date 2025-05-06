using BrainstormingFoodTek.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscount _discountService;

        public DiscountController(IDiscount discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("Get-allDiscounts")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = await _discountService.GetAllDiscount();
            return Ok(discounts);
        }
    }
}
