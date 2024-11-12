namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Shipping
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShippingMethod { get; set; }
        public decimal ShippingCost { get; set; }
        public string TrackingNumber { get; set; }

        public Order Order { get; set; }
        public Account Account { get; set; }
    }

    public class ShippingCreateDto
    {
        public string ShippingAddress { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShippingMethod { get; set; }
        public decimal ShippingCost { get; set; }
        public string TrackingNumber { get; set; }
    }

    public class ShippingGetDto
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShippingMethod { get; set; }
        public decimal ShippingCost { get; set; }
        public string TrackingNumber { get; set; }
    }
}
