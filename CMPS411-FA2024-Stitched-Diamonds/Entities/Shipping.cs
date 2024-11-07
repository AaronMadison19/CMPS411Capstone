namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Shipping
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public decimal Cost { get; set; }
        public string Tracking_Number { get; set; }
        public DateTime Estimated_Delivery { get; set; }
        public DateTime Shipped_Date { get; set; }
        public string Delivery_Status { get; set; }
    }
}
