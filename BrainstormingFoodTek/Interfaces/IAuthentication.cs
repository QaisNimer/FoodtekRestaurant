using BrainstormingFoodTek.DTOs.Registration.Request;
using FoodtekAPI.DTOs.SignIn.Request;
using FoodtekAPI.DTOs.SignIns.Request;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Interfaces
{
    public interface IAuthentication
    {
        Task<string> SignUp(RegistrationRequestDTO input);
        Task<string> SignIn(SignInRequestDTO input);
        Task<bool> ResetPassword(ResetPasswordRequestDTO input);
        Task<string> Verification(VerificationRequestDTO input);
    }
}
