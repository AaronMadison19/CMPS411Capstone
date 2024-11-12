namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int AccountId { get; set; }
        public int SessionId { get; set; }
        public int ShippingId { get; set; }
        public string OrderStatus { get; set; }

        public Account Account { get; set; }
        public Session Session { get; set; }
        public Shipping Shipping { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class OrderCreateDto
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int AccountId { get; set; }
        public int SessionId { get; set; }
        public int ShippingId { get; set; }
        public string OrderStatus { get; set; }
    }

    public class OrderUpdateDto
    {
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
    }

    public class OrderGetDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
    }
}
