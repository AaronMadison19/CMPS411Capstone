namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Cart_Item
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VariantId { get; set; }
        public Product_Variant Product_Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart_ItemGetDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartGetDto Cart { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto Product { get; set; }
        public int VariantId { get; set; }
        public Product_VariantGetDto Product_Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart_ItemCreateDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart_ItemUpdateDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
