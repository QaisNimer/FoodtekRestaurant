using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Helpers.ItemsValidation
{
    public class ItemsValidation
    {
        private readonly RestaurantDbContext _foodtekDbContext;
        public ItemsValidation(RestaurantDbContext foodtekDbContext)
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
