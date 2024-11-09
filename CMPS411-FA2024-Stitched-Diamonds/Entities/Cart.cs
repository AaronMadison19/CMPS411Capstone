namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool Is_Active { get; set; }
    }

    public class CartGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserGetDto User { get; set; }
        public int SessionId { get; set; }
        public SessionGetDto Session { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool Is_Active { get; set; }
    }

    public class CartCreateDto
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool Is_Active { get; set; }
    }

    public class CartUpdateDto
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool Is_Active { get; set; }
    }
}
