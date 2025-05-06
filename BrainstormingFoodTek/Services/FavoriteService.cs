using BrainstormingFoodTek.DTOs.FavoriteDTOs.Request;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;
using Microsoft.EntityFrameworkCore;

namespace BrainstormingFoodTek.Services
{
    public class FavoriteService: IFavorite
    {
        private readonly FoodtekDbContext _Context;
        public FavoriteService(FoodtekDbContext Context)
        {
            _Context = Context;
        }
        public async Task<string> AddToFavorite(FavoriteRequestDTO FavoriteDTO)
        {
            var favorite = await _Context.FavoriteItems
            .Where(x => x.ClientId == FavoriteDTO.ClientId)
            .SingleOrDefaultAsync();

            if (favorite == null)
            {
                return "User Not Found!";
            }
            favorite.ItemId = FavoriteDTO.ItemsID;
            _Context.Update(favorite);
            _Context.SaveChanges();

            return "Add Successfully";
        }

        public async Task<string> RemoveFromFavorite(int itemId)
        {
            var favorite = _Context.FavoriteItems.Where(c => c.ItemId == itemId).FirstOrDefault();
            if (favorite == null)
            {
                return "Item does not exist";
            }

            _Context.Remove(favorite);
            _Context.SaveChanges();

            return "Wishlist Item Removed Successfully";
        }

    }
}
