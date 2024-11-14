namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalSales { get; set; }
        public DateTime SaleDate { get; set; }

        public Product Product { get; set; }
    }

    public class SalesCreateDto
    {
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalSales { get; set; }
        public DateTime SaleDate { get; set; }
    }

    public class SalesGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalSales { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
