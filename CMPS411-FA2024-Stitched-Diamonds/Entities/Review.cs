namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Created_At { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Rating { get; set; }
        public bool Is_Visible { get; set; }
    }
}
