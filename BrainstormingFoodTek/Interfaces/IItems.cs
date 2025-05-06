using BrainstormingFoodTek.DTOs.ItemsDTOs.Response;

namespace BrainstormingFoodTek.Interfaces
{
    public interface IItems
    {
        Task<List<TopRatedItemsResponseDTO>> GetTopRatedItems();
        Task<List<TopRecommendedItemDTO>> TopRecommendedItems();
        Task<List<ItemByCategoryDTO>> GetItemByCategory(int categoryId);
        Task<List<FavoriteItemDTO>> GetFavoriteItemByUserId(int UserId);
        Task<ItemDTO> GetOneItem(int ItemId);
    }
}
