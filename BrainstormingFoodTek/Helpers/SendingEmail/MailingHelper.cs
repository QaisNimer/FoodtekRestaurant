using SendGrid.Helpers.Mail;
using SendGrid;

namespace BrainstormingFoodTek.Helpers.SendingEmail
{
    public class MailingHelper
    {
        public async Task SendEmail(string email, string otp, string title, string message)
        {
			try
			{
                var apiKey = "SendGrid:ApiKey";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("apptraines@gmail.com", "Brainstorming Foodtek");
                var subject = title;
                var to = new EmailAddress(email, "Password Manager User");
                var plainTextContent = $"Dear User {message} Please Use Tis OTP {otp} It Will Be Expired After 10 Minutes ";
                //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, "");
                var response = await client.SendEmailAsync(msg);
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
