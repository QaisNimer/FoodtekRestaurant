namespace BrainstormingFoodTek.DTOs.NotificationsDTOs.Response
{
    public class NotificationResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
