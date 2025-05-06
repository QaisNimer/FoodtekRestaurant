using BrainstormingFoodTek.DTOs.FavoriteDTOs.Request;

namespace BrainstormingFoodTek.Interfaces
{
    public interface IFavorite
    {
        Task<string> AddToFavorite(FavoriteRequestDTO FavoriteDTO);
        Task<string> RemoveFromFavorite(int itemId);
    }
}
