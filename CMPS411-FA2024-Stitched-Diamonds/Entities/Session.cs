namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }  // Changed from userId to accountId
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public Account? Account { get; set; }  // Updated relationship to Account instead of User
    }

    public class SessionCreateDto
    {
        public int? AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class SessionGetDto
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
