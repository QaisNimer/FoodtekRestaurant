using BrainstormingFoodTek.DTOs.Registration.Request;
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
