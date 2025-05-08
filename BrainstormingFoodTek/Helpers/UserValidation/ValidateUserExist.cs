using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Helpers.UserValidation
{
    public class ValidateUserExist
    {
        private readonly RestaurantDbContext _foodtekDbContext;
        public ValidateUserExist(RestaurantDbContext foodtekDbContext)
        {
            _foodtekDbContext = foodtekDbContext;
        }
        public bool IsUserValid(int id)
        {
            try
            {
                var item = _foodtekDbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
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
