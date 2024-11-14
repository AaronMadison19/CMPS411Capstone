namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public int? SessionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Account? Account { get; set; }
        public Session? Session { get; set; }  
        public bool IsActive { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }

    public class CartCreateDto
    {
        public int? AccountId { get; set; }
        public int? SessionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

    }

    public class CartGetDto
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public int? SessionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public AccountGetDto? Account { get; set; }
        public SessionGetDto? Session { get; set; }
        public bool IsActive { get; set; }
    }

    public class CartUpdateDto
    {
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
