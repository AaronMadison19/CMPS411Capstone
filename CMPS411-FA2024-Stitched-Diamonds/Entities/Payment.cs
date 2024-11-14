namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }

        public Order Order { get; set; }
    }

    public class PaymentCreateDto
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
    }

    public class PaymentGetDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }

        public OrderGetDto Order { get; set; }
    }

    public class PaymentUpdateDto
    {
        public string Status { get; set; }
    }
}
