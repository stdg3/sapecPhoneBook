using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using test.Models;

namespace test.ViewModel.Contacts
{
    public class ContactAllDataViewModel
    {
        public ContactDetailsPartialViewModel? ContactPartial { get; set; }
        
        //public int ContactId { get; set; }
        //public string ContactFirstName { get; set; } = default!;
        //public string? ContactLastName { get; set; }
        //public string? ContactAdress { get; set; }
        public ICollection<NumbersOfContact> NumbersOfContacts { get; set; } //= new ICollection<NumbersOfContact>();


        //from NumsOfContactModel
        public int NumbersOfContactId { get; set; }

        //[Display(Name = "asdasdasdasd")] //, Order = -9, Prompt = "Enter Last Name", Description = "Emp Last Name")
        [Display(Name = "Release Date")]
        public string? NumbersOfContactNumber { get; set; }

        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; } = default!;
        //public ICollection<PhoneType> PhoneTypes { get; set; }
        //public int ContactId { get; set; }
        public Contact Contact { get; set; } = default!;
    }
}
