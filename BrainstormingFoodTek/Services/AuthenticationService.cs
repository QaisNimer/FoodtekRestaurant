using BrainstormingFoodTek.DTOs.Registration.Request;
using BrainstormingFoodTek.Helpers.OTPUserSelection;
using BrainstormingFoodTek.Helpers.ValidationFields;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainstormingFoodTek.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly RestaurantDbContext _foodtekDbContext;
        private readonly OTPBasedOnUserRole _otpBasedOnUserRole;
        private readonly ITokenProvider _tokenProvider;
        public AuthenticationService(RestaurantDbContext foodtekDbContext, OTPBasedOnUserRole otpBasedOnUserRole
            , ITokenProvider tokenProvider)
        {
            _foodtekDbContext = foodtekDbContext;
            _otpBasedOnUserRole = otpBasedOnUserRole;
            _tokenProvider = tokenProvider;
        }
        public async Task<string> SignUp(RegistrationRequestDTO input)
        {

            User user = new User();
            if (!(ValidationHelpers.IsValidEmail(input.Email) || ValidationHelpers.IsValidatePassword(input.Password)))
            {
                return $"Not Valid Email or Password";
            }
            if (!(ValidationHelpers.IsValidName(input.firstname) || ValidationHelpers.IsValidName(input.lastname)))
            {
                return $"Not Valid FirstName or LastName";
            }
            if (!(ValidationHelpers.IsValidatteBirthDate(input.BirthDate)))
            {
                return $"Not Birthdate";
            }
            user.Email = input.Email;
            user.Password = input.Password;
            user.FirstName = input.firstname;
            user.PhoneNumber = input.Phonenum;
            user.LastName = input.lastname;
            user.UserTypeId = 3;
            user.StatusId =6 ;
            user.CreatedBy = "System";
            user.CreationDate = DateTime.Now;

            //Random random = new Random();
            //var otp = random.Next(1111, 9999);
            //user.Otp = otp.ToString();

            //user.ExpireOtp = DateTime.Now.AddMinutes(10);
            _foodtekDbContext.Users.Add(user);
            _foodtekDbContext.SaveChanges();
            if (user.UserId>0)
            {
                _foodtekDbContext.Update(await _otpBasedOnUserRole.OTPBasedOnUserType(user.Email, "OTP for Sign Up.", "Completed Log Up.", user));
                _foodtekDbContext.SaveChanges();
            }
            return "Verifying Your email using otp";
        }
        public async Task<string> SignIn(SignInRequestDTO input)
        {
            try
            {
                var user = await _foodtekDbContext.Users.Where(u => u.Email == input.Email && u.Password == input.Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    return $"No User Found";

                }
                if (!ValidationHelpers.IsValidEmail(input.Email) || !ValidationHelpers.IsValidEmail(input.Password))
                {
                    return $"Not Valid Email or Password";
                }

                _foodtekDbContext.Update(await _otpBasedOnUserRole.OTPBasedOnUserType(user.Email, "OTP for Sign In.", "Completed Log In.", user));
                _foodtekDbContext.SaveChanges();
                return "Check your email OTP has been sent!";

            }
            catch (Exception ex)
            {
                return $" Can't SignIn Try Again{ex.Message}";
            }
        }

        public async Task<bool> ResetPassword(ResetPasswordRequestDTO input)
        {
            var user = _foodtekDbContext.Users.Where(u => u.Email == input.Email && u.Otp == input.OTP
             && u.IsLoggedIn == false && u.ExpireOtp > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            if (input.Password != input.ConfirmPassword)
            {
                return false;
            }
            user.Otp = null;
            user.ExpireOtp = null;

            _foodtekDbContext.Update(user);
            _foodtekDbContext.SaveChanges();

            return true;
        }

        public async Task<string> Verification(VerificationRequestDTO input)
        {
            var user = _foodtekDbContext.Users.Where(u => u.Email == input.Email && u.Otp == input.OTPCode
            && u.IsLoggedIn == false && u.ExpireOtp > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return "User not found";
            }

            if (input.IsSignup)
            {
                user.IsVerified = true;
                user.ExpireOtp = null;
                user.Otp = null;
                _foodtekDbContext.Update(user);
                _foodtekDbContext.SaveChanges();
                return "Your Account Is Verifyed";
            }
            else
            {
                user.LastLoggedIn = DateTime.Now;
                user.IsLoggedIn = true;
                user.ExpireOtp = null;
                user.Otp = null;

                _foodtekDbContext.Update(user);
                _foodtekDbContext.SaveChanges();
                string jwtToken = _tokenProvider.CreateToken(user);
                return jwtToken;
            }
        }
    }
}
