namespace BrainstormingFoodTek.DTOs.CartDTOs.Request
{
    public class CartRequestDTO
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public int? CartItemID { get; set; }
    }
}
