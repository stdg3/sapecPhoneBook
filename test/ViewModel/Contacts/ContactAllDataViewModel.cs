using test.Models;

namespace test.ViewModel.Contacts
{
    public class ContactAllDataViewModel
    {
        public int ContactId { get; set; }
        public string ContactFirstName { get; set; } = default!;
        public string? ContactLastName { get; set; }
        public string? ContactAdress { get; set; }
        //public ApplicationUser User { get; set; } = default!;
        //public string UserId { get; set; } = default!;
        //public int NumbersOfContactId { get; set; }

        public List<NumbersOfContact> NumbersOfContacts { get; set; } = new List<NumbersOfContact>();
        //from NumsOfContactModel
        public int NumbersOfContactId { get; set; }
        public string? NumbersOfContactNumber { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; } = default!;
        //public ICollection<PhoneType> PhoneTypes { get; set; }
        //public int ContactId { get; set; }
        public Contact Contact { get; set; } = default!;
    }
}
