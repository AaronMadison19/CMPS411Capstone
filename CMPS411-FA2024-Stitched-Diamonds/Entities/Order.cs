namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public decimal Total_Price { get; set; }
        public string Payment_Method { get; set; }
        public string Payment_Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
        public string Order_Status { get; set; }
    }
}
