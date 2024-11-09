namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Sub_Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Subtype { get; set; }
    }

    public class Sub_CategoryGetDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryGetDto Category { get; set; }
        public string Subtype { get; set; }
    }

    public class Sub_CategoryCreateDto
    {
        public int CategoryId { get; set; }
        public string Subtype { get; set; }
    }

    public class Sub_CategoryUpdateDto
    {
        public int CategoryId { get; set; }
        public string Subtype { get; set; }
    }
}
