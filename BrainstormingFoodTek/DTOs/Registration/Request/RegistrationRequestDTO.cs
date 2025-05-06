namespace BrainstormingFoodTek.DTOs.Registration.Request
{
    public class RegistrationRequestDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phonenum { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
