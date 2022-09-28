namespace test.Models
{
    public class NumbersOfContact
    {
        public int NumbersOfContactId { get; set; }
        public string? NumbersOfContactNumber { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; } = default!;
        //public ICollection<PhoneType >PhoneTypes { get; set; }
        //public int ContactId { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; } = default!;
        //public ICollection<Contact> Contacts { get; set; }
    }
}
