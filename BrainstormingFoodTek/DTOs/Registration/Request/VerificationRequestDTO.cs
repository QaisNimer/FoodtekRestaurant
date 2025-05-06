namespace FoodtekAPI.DTOs.SignIn.Request
{
    public class VerificationRequestDTO
    {
        public string Email { get; set; }

        public string OTPCode { get; set; }

        public bool IsSignup { get; set; }
    }
}
