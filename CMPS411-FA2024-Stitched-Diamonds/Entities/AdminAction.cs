namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class AdminAction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public string ActionType { get; set; }
        public DateTime ActionDate { get; set; }
        public string Details { get; set; }

        public Product Product { get; set; }
        public Account Account { get; set; }
    }

    public class AdminActionCreateDto
    {
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public string ActionType { get; set; }
        public string Details { get; set; }
        public DateTime ActionDate { get; set; }

    }

    public class AdminActionGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public string ActionType { get; set; }
        public DateTime ActionDate { get; set; }
        public string Details { get; set; }
        public ProductGetDto Product { get; set; }
        public AccountGetDto Account { get; set; }

    }
}
