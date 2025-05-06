using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Helpers.UserValidation
{
    public class ValidateUserExist
    {
        private readonly FoodtekDbContext _foodtekDbContext;
        public ValidateUserExist(FoodtekDbContext foodtekDbContext)
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
