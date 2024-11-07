namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime Payment_Date { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Method { get; set; }
        public string Status { get; set; }
    }
}
