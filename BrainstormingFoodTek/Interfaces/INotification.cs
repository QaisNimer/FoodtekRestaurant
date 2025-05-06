using BrainstormingFoodTek.DTOs.CategoryDTOs.Response;
using BrainstormingFoodTek.DTOs.NotificationsDTOs.Response;

namespace BrainstormingFoodTek.Interfaces
{
    public interface INotification
    {
        Task<List<NotificationResponseDTO>> GetNotificationsByUserId(int userId);
    }
}
