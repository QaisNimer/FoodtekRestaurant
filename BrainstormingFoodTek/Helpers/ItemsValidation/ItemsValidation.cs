using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Helpers.ItemsValidation
{
    public class ItemsValidation
    {
        private readonly FoodtekDbContext _foodtekDbContext;
        public ItemsValidation(FoodtekDbContext foodtekDbContext)
        {
            _foodtekDbContext = foodtekDbContext;
        }
        public bool IsItemValid(int id) {
            try
            {
                var item = _foodtekDbContext.Items.Where(x => x.ItemId == id).FirstOrDefault();
                if (item == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
