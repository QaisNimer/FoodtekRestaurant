using BrainstormingFoodTek.Helpers.UserValidation;
using BrainstormingFoodTek.Models;
using BrainstormingFoodTek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationServices _getNotificationsByUserId;
        private readonly RestaurantDbContext _foodtekDbContext;
        private readonly ValidateUserExist _validateUserExist;
        public NotificationController(NotificationServices notificationServices, RestaurantDbContext restaurantDbContext, 
            ValidateUserExist validateUserExist)
        {
            _getNotificationsByUserId = notificationServices;
            _foodtekDbContext = restaurantDbContext;
            _validateUserExist = validateUserExist;
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetUserNotifications(int userId)
        {
            var result = await _getNotificationsByUserId.GetNotificationsByUserId(userId);
            return Ok(result);
        }
    }
}
