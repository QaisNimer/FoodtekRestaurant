using BrainstormingFoodTek.DTOs.Registration.Request;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Interfaces
{
    public interface IAuthentication
    {
        Task<string> SignUp(RegistrationRequestDTO input);
        Task<string> SignIn(SignInRequestDTO input);
        Task<string> ResetPassword(ResetPasswordRequestDTO input);
        Task<string> SendOTPToResetPassword(string email);
        Task<string> Verification(VerificationRequestDTO input);
    }
}
