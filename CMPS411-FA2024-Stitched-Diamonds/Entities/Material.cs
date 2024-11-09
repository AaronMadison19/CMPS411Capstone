namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Is_Allergen_Free { get; set; }
        public int Quantity_In_Stock { get; set; }
        public decimal Cost {  get; set; } 
        public int Reorder_Level { get; set; }
        public int Reorder_Quantity { get; set; }
    }

    public class MaterialGetDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Is_Allergen_Free { get; set; }
        public int Quantity_In_Stock { get; set; }
        public decimal Cost { get; set; }
        public int Reorder_Level { get; set; }
        public int Reorder_Quantity { get; set; }
    }

    public class MaterialCreateDto
    {
        public string Type { get; set; }
        public bool Is_Allergen_Free { get; set; }
        public int Quantity_In_Stock { get; set; }
        public decimal Cost { get; set; }
        public int Reorder_Level { get; set; }
        public int Reorder_Quantity { get; set; }
    }

    public class MaterialUpdateDto
    {
        public string Type { get; set; }
        public bool Is_Allergen_Free { get; set; }
        public int Quantity_In_Stock { get; set; }
        public decimal Cost { get; set; }
        public int Reorder_Level { get; set; }
        public int Reorder_Quantity { get; set; }
    }
}
