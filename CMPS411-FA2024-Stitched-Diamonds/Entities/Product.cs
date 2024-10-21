namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity_In_Stock { get; set; }

    }
}
