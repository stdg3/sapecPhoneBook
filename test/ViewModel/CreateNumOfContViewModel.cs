using Microsoft.AspNetCore.Mvc.Rendering;

namespace test.ViewModel
{
    public class CreateNumOfContViewModel
    {
        public string? NumbersOfContactNumber { get; set; }
        public int ContactId { get; set; }
        public int? PhoneTypeId { get; set; }
        public List<SelectListItem>? PhoneTypesList { get; set; }

        //public string ContactName { get; set; }
        //public string ContactNumber { get; set; }
        //public int SelectedTypeId { get; set; }
        //public List<SelectListItem>? PhoneTypesSelectedList { get; set; }
    }
}
