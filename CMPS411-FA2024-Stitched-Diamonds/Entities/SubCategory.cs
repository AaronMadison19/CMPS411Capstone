namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Subtype { get; set; }  // e.g., "Hats", "Earrings"

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }

    }
    public class SubcategoryGetDto
    {
        public int Id { get; set; }
        public string Subtype { get; set; }
        public int CategoryId { get; set; }
        public CategoryGetDto Category {  get; set; }
        public List<ProductGetDto> Products { get; set; }
    }

    public class SubcategoryCreateDto
    {
        public string Subtype { get; set; }
        public int CategoryId { get; set; }
    }

    public class SubcategoryUpdateDto
    {
        public string Subtype { get; set; }
        public int CategoryId { get; set; }
    }
}
