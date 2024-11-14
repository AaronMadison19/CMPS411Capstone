namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsVisible { get; set; }
        public Product Product { get; set; }
        public Account Account { get; set; }
    }

    public class ReviewCreateDto
    {
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsVisible { get; set; }
    }

    public class ReviewGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsVisible { get; set; }
    }

    public class ReviewUpdateDto
    {
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool IsVisible { get; set; }
    }
}
