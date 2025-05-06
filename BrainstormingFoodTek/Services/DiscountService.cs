using BrainstormingFoodTek.DTOs.DiscountDTOs.Response;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Services
{
    public class DiscountService : IDiscount
    {
        private readonly FoodtekDbContext _Context;

        public DiscountService(FoodtekDbContext context)
        {
            _Context = context;
        }
        public async Task<List<DiscountResponseDTO>> GetAllDiscount()
        {
            try
            {
                var discounts = _Context.Discounts.ToList();

                var discountsDTOs = discounts.Select(d => new DiscountResponseDTO
                {

                    ArabicTitle = d.TitleAr,
                    EnglishTitle = d.TitleEn,
                    ArabicDescription = d.DescriptionAr,
                    EnglishDescription = d.DescriptionEn,
                    ImageUrl = d.ImageUrl,
                }).ToList();

                return discountsDTOs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
