namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public ProductVariant ProductVariant { get; set; }
    }

    public class CartItemCreateDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class CartItemGetDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
