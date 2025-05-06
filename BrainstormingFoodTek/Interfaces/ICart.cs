using BrainstormingFoodTek.DTOs.CartDTOs.Request;

namespace BrainstormingFoodTek.Interfaces
{
    public interface ICart
    {
        Task<string> AddItemToCart(CartRequestDTO itemDTO);
    }
}
