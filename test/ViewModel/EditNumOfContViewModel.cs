using Microsoft.AspNetCore.Mvc.Rendering;

namespace test.ViewModel
{
    public class EditNumOfContViewModel
    {
        public int NumbersOfContactId { get; set; }
        public string? NumbersOfContactNumber { get; set; }
        public int ContactId { get; set; }
        public int PhoneTypeId { get; set; }
        public List<SelectListItem>? PhoneTypesList { get; set; }
    }
}
