using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace test.Models
{
    public class PhoneType
    {
        public int PhoneTypeId { get; set; }
        [Display(Name = "Phone adssdasdasda")]
        public string? PhoneTypeName { get; set; }
        //public ICollection<Contact> Contacts { get; set; }
        public ICollection<NumbersOfContact>? NumberOfContacts { get; set; }
        //public int NumberOfContactId { get; set; }
    }

}
