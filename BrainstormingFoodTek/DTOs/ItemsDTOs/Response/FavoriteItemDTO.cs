using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.DTOs.ItemsDTOs.Response
{
    public class FavoriteItemDTO
    {
        public int Id { get; set; } 
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; } 
        
    }
}
