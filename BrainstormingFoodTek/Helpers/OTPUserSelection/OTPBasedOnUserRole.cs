using BrainstormingFoodTek.Models;
using BrainstormingFoodTek.Helpers.SendingEmail;

namespace BrainstormingFoodTek.Helpers.OTPUserSelection
{
    public class OTPBasedOnUserRole
    {
        private readonly MailingHelper _mailingHelper;
        public OTPBasedOnUserRole(MailingHelper mailingHelper)
        {
            _mailingHelper = mailingHelper;
        }
        public async Task<User> OTPBasedOnUserType(string Email,string title, string message, User us) {
            var otp=111111;
            var expireDate=DateTime.Now;
            Random rand = new Random();
            switch (us.UserTypeId)
            {
                case 1:
                case 2:
                    otp = rand.Next(11111, 99999);
                    expireDate = DateTime.Now.AddMinutes(10);
                    break;

                case 3:
                case 5:
                     otp = rand.Next(11111, 99999);
                    expireDate = DateTime.Now.AddMinutes(60);
                    break;
                
                default:
                    Console.WriteLine("This Role Doesn't Have OTP");
                    break;           
            }
            us.Otp = otp.ToString();
            us.ExpireOtp = expireDate;
            await _mailingHelper.SendEmail(us.Email, us.Otp, title, message);
            return us;

        }
    }
}
