namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsAllergenFree { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Cost { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class MaterialCreateDto
    {
        public string Type { get; set; }
        public bool IsAllergenFree { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Cost { get; set; }
    }

    public class MaterialGetDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsAllergenFree { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Cost { get; set; }
    }

    public class MaterialUpdateDto
    {
        public string Type { get; set; }
        public bool IsAllergenFree { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Cost { get; set; }
    }
}
