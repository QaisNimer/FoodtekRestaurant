using BrainstormingFoodTek.Models;

namespace BrainstormingFoodTek.Interfaces
{
    public interface ITokenProvider
    {
        string CreateToken(User user);
    }
}
