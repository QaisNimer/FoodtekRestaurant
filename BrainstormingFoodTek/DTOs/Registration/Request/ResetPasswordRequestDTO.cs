namespace BrainstormingFoodTek.DTOs.Registration.Request
{
    public class ResetPasswordRequestDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
