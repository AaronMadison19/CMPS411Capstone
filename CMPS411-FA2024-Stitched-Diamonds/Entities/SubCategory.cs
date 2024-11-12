namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Subtype { get; set; }  // e.g., "Hats", "Earrings"

        // Navigation property for the relationship to Product
        public ICollection<Product> Products { get; set; }
    }
    public class SubcategoryGetDto
    {
        public int Id { get; set; }
        public string Subtype { get; set; }
        public List<ProductGetDto> Products { get; set; }
    }

    public class SubcategoryCreateDto
    {
        public string Subtype { get; set; }
    }
}
