namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Admin_Action
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public User User { get; set; }
        public string Action_Type { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Action_TimeStamp { get; set; }
        public string Details { get; set; }
    }

    public class Admin_ActionGetDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public UserGetDto User { get; set; }
        public string Action_Type { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto Product { get; set; }
        public DateTime Action_TimeStamp { get; set; }
        public string Details { get; set; }
    }

    public class Admin_ActionCreateDto
    {
        public int AdminId { get; set; }
        public string Action_Type { get; set; }
        public int ProductId { get; set; }
        public DateTime Action_TimeStamp { get; set; }
        public string Details { get; set; }
    }

    public class Admin_ActionUpdateDto
    {
        public int AdminId { get; set; }
        public string Action_Type { get; set; }
        public int ProductId { get; set; }
        public DateTime Action_TimeStamp { get; set; }
        public string Details { get; set; }
    }
}
