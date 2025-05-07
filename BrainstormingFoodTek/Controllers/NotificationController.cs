using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotification _getNotificationsByUserId;

        public NotificationController(INotification notificationServices)
        {
            _getNotificationsByUserId = notificationServices;
        }


        [HttpGet("notifications")]
        public async Task<IActionResult> GetUserNotifications(int userId)
        {
            var result = await _getNotificationsByUserId.GetNotificationsByUserId(userId);
            return Ok(result);
        }
    }
}
