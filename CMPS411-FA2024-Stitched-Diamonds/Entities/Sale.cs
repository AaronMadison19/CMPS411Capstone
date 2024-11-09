namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int Quantity_Sold { get; set; }
        public decimal Unit_Price { get; set; }
    }

    public class SaleGetDto
    {
        public int Id { get; set; }
        public int Quantity_Sold { get; set; }
        public decimal Unit_Price { get; set; }
    }

    public class SaleCreateDto
    {
        public int Quantity_Sold { get; set; }
        public decimal Unit_Price { get; set; }
    }

    public class SaleUpdateDto
    {
        public int Quantity_Sold { get; set; }
        public decimal Unit_Price { get; set; }
    }
}
