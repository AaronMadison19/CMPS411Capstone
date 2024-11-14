namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }

    }

    public class CategoryCreateDto
    {
        public string Type { get; set; }
    }

    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<ProductGetDto> Products { get; set; }
    }

    public class CategoryUpdateDto
    {
        public string Type { get; set; }
    }
}
