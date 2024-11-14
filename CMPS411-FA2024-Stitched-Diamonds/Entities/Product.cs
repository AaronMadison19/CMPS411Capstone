namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string Details { get; set; }
        public int MaterialId { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }

        public Category Category { get; set; }
        public Material Material { get; set; }
        public Subcategory Subcategory { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<AdminAction> AdminActions { get; set; }
    }

    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        
        public int SubcategoryId { get; set; }
        public string Details { get; set; }
        public int MaterialId { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }

    }

    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public int MaterialId { get; set; }
        public int SubcategoryId { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }

    }

    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string Details { get; set; }
        public int MaterialId { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }


        public CategoryGetDto Category { get; set; }
        public MaterialGetDto Material { get; set; }
        public SubcategoryGetDto Subcategory { get; set; }
    }
}
