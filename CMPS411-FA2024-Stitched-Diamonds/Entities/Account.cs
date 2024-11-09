namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string Billing_Address { get; set; }
        public string Shipping_Address { get; set; }
        public DateTime Create_Date { get; set; }
        public bool Is_Active { get; set; }
        public string Role { get; set; }
    }

    public class AccountGetDto
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Phone_Number { get; set; }
        public string Billing_Address { get; set; }
        public string Shipping_Address { get; set; }
        public DateTime Create_Date { get; set; }
        public bool Is_Active { get; set; }
        public string Role { get; set; }
    }

    public class AccountCreateDto
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string Billing_Address { get; set; }
        public string Shipping_Address { get; set; }
        public DateTime Create_Date { get; set; }
        public bool Is_Active { get; set; }
        public string Role { get; set; }
    }

    public class AccountUpdateDto
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string Billing_Address { get; set; }
        public string Shipping_Address { get; set; }
        public DateTime Create_Date { get; set; }
        public bool Is_Active { get; set; }
        public string Role { get; set; }
    }
}
