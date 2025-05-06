using BrainstormingFoodTek.DTOs.CategoryDTOs.Response;
using BrainstormingFoodTek.DTOs.DiscountDTOs.Response;

namespace BrainstormingFoodTek.Interfaces
{
    public interface IDiscount
    {
        Task<List<DiscountResponseDTO>> GetAllDiscount();

    }
}
