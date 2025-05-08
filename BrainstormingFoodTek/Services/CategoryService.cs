using BrainstormingFoodTek.DTOs.CategoryDTOs.Response;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Services
{
    public class CategoryService: ICategory
    {
        private readonly RestaurantDbContext _Context;

        public CategoryService(RestaurantDbContext context)
        {
            _Context = context;
        }
        public async Task<List<CategoryResponseDTO>> GetAllCategory()
        {
            try
            {
                var categories = _Context.Categories.ToList();

                var categoriesDTOs = categories.Select(d => new CategoryResponseDTO
                {
                    ArabicName = d.NameAr,
                    EnglishName = d.NameEn,
                    ImagePath = d.ImagePath,
                }).ToList();

                return categoriesDTOs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
