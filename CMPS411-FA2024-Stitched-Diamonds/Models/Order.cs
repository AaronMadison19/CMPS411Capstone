namespace CMPS411_FA2024_Stitched_Diamonds.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public decimal Total_Price { get; set; }
        public string Payment_Method { get; set; }
    }
}
