using Microsoft.AspNetCore.Mvc.Rendering;
using test.Models;

namespace test.ViewModel.Contacts
{
    public class CreateCartViewmModel
    {
        //FROM CONTACT MODEL
        public string ContactFirstName { get; set; } = default!;
        public string? ContactLastName { get; set; }
        public string? ContactAdress { get; set; }
        //public ApplicationUser User { get; set; } = default!;
        //public string UserId { get; set; } = default!;
        //public int NumbersOfContactId { get; set; }
        //public ICollection<NumbersOfContact> NumbersOfContacts { get; set; }


        //FROM NUMSOFCONTACS
        public string? NumbersOfContactNumber { get; set; }
        public int? PhoneTypeId { get; set; }
        //public PhoneType PhoneType { get; set; } = default!;
        //public List<SelectListItem>? PhoneTypes { get; set; }
        //public int ContactId { get; set; }
        //public Contact Contact { get; set; } = default!;

    }
}
