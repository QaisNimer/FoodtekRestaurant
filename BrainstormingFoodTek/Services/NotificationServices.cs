using BrainstormingFoodTek.Models;
using BrainstormingFoodTek.Helpers.UserValidation;
using BrainstormingFoodTek.Interfaces;
using Microsoft.EntityFrameworkCore;
using BrainstormingFoodTek.DTOs.NotificationsDTOs.Response;

namespace BrainstormingFoodTek.Services
{
    public class NotificationServices: INotification
    {
        private readonly FoodtekDbContext _foodtekDbContext;
        private readonly ValidateUserExist _validateUserExist;
       
        public NotificationServices(FoodtekDbContext foodtekDbContext, ValidateUserExist validateUserExist)
        {
            _foodtekDbContext = foodtekDbContext;
            _validateUserExist = validateUserExist;
            
        }
        public async Task<List<NotificationResponseDTO>> GetNotificationsByUserId(int userId)
        {
            try
            {
                if (_validateUserExist.IsUserValid(userId)==true)
                {
                    var notifications = await _foodtekDbContext.Notifications
                .Where(n => n.NotificationId == userId)
                .OrderByDescending(n => n.CreationDate)
                .Select(n => new NotificationResponseDTO
                {
                    Id = n.NotificationId,
                    Title = n.Title,
                    Content = n.Message,
                    Date = n.CreationDate,
                    IsRead = Convert.ToBoolean(n.IsRead),
                })
                .ToListAsync();

                    return notifications;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
