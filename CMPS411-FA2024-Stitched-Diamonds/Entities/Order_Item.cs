namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Order_Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Product_VariantId { get; set; }
        public Product_Variant Product_Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Order_ItemGetDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderGetDto Order { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto Product { get; set; }
        public int Product_VariantId { get; set; }
        public Product_VariantGetDto Product_Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Order_ItemCreateDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Product_VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Order_ItemUpdateDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Product_VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
