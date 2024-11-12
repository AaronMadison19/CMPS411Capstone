namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string VariantName { get; set; }
        public string VariantValue { get; set; }
        public decimal AdditionalPrice { get; set; }

        public Product Product { get; set; }
    }

    public class ProductVariantCreateDto
    {
        public int ProductId { get; set; }
        public string VariantName { get; set; }
        public string VariantValue { get; set; }
        public decimal AdditionalPrice { get; set; }
    }

    public class ProductVariantGetDto
    {
        public int Id { get; set; }
        public string VariantName { get; set; }
        public string VariantValue { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}
