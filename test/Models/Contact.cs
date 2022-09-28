namespace test.Models
{
    public class Contact
    {

        public int ContactId { get; set; }
        public string ContactName { get; set; } = default!;
        public string? ContactNumber { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}
