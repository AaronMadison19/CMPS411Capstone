namespace CMPS411_FA2024_Stitched_Diamonds.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }  // e.g., 'Customer', 'Admin', 'Guest'

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }

    public class AccountCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Role { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class AccountUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public bool IsActive { get; set; }
    }

    public class AccountGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Role { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}