namespace test.Models
{
    public class Contact
    {

        public int ContactId { get; set; }
        public string ContactFirstName { get; set; } = default!;
        public string? ContactLastName { get; set; }
        public string? ContactAdress { get; set; }
        public ApplicationUser User { get; set; } = default!;
        public string UserId { get; set; } = default!;
        //public int NumbersOfContactId { get; set; }
        public ICollection<NumbersOfContact> NumbersOfContacts { get; set; }
        //public int PhoneTypeId { get; set; }
        //public PhoneType PhoneType { get; set; }
    }
}
