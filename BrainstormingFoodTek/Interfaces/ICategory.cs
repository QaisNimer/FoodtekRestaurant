using BrainstormingFoodTek.DTOs.CategoryDTOs.Response;
using BrainstormingFoodTek.DTOs.ItemsDTOs.Response;

namespace BrainstormingFoodTek.Interfaces
{
    public interface ICategory
    {
        Task<List<CategoryResponseDTO>> GetAllCategory();
    }
}
