using BrainstormingFoodTek.DTOs.FavoriteDTOs.Request;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainstormingFoodTek.Controllers
{
    public class FavoriteController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IFavorite _favoriteService;

        public FavoriteController(RestaurantDbContext context, IFavorite favoriteService)
        {
            _context = context;
            _favoriteService = favoriteService;
        }

        [HttpPost("Add-To-Favorite")]
        public async Task<IActionResult> AddToFavorite([FromBody] FavoriteRequestDTO favoriteDTO)
        {
            try
            {

                if (favoriteDTO.ClientId <= 0 || favoriteDTO.ItemsID <= 0)
                    return BadRequest("ClientId and ItemId must be greater than zero.");
                var clientExists = await _context.Clients.AnyAsync(c => c.ClientId == favoriteDTO.ClientId);
                var itemExists = await _context.Items.AnyAsync(i => i.ItemId == favoriteDTO.ItemsID);

                if (!clientExists || !itemExists)
                    return NotFound("Client or Item not found in the database.");
                var result = await _favoriteService.AddToFavorite(favoriteDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Remove-Item-From-Favorite/{itemId}")]
        public async Task<IActionResult> RemoveFromFavorite([FromRoute] int itemId)
        {
            try
            {

                if (itemId <= 0)
                {
                    throw new Exception("Invalid Item Id, Id Must Be Greater Than Zero");
                }

                var itemExists = await _context.Items.AnyAsync(i => i.ItemId == itemId);
                if (!itemExists)
                {
                    return NotFound("Item not found in the Favorite.");
                }

                var result = await _favoriteService.RemoveFromFavorite(itemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
