namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public string Details { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int Quantity_In_Stock { get; set; }
        public int Created_By { get; set; }
        public User User { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string ImageUrl { get; set; }

    }
}
