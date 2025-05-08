using BrainstormingFoodTek.DTOs.FavoriteDTOs.Request;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;
using Microsoft.EntityFrameworkCore;

namespace BrainstormingFoodTek.Services
{
    public class FavoriteService: IFavorite
    {
        private readonly RestaurantDbContext _Context;
        public FavoriteService(RestaurantDbContext Context)
        {
            _Context = Context;
        }
        public async Task<string> AddToFavorite(FavoriteRequestDTO FavoriteDTO)
        {
           FavoriteItem favoriteItem = new FavoriteItem();
            favoriteItem.ItemId = FavoriteDTO.ItemsID;
            favoriteItem.ClientId = FavoriteDTO.ClientId;
            _Context.FavoriteItems.Add(favoriteItem);
            _Context.SaveChanges();
            return "Add Successfully";
            //
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
