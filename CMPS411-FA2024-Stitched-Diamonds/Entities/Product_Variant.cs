namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Product_Variant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        
    }

    public class Product_VariantGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto Product { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Product_VariantCreateDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Product_VariantUpdateDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
