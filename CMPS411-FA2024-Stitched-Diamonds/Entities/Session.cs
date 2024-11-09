namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Expires_At { get; set; }

    }

    public class SessionGetDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public UserGetDto User { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Expires_At { get; set; }
    }

    public class SessionCreateDto
    {
        public int? UserId { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Expires_At { get; set; }
    }

    public class SessionUpdateDto
    {
        public int? UserId { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Expires_At { get; set; }
    }
}
