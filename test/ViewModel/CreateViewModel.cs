using Microsoft.AspNetCore.Mvc.Rendering;

namespace test.ViewModel
{
    public class CreateViewModel
    {
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public int SelectedTypeId { get; set; }
        public List<SelectListItem>? PhoneTypesSelectedList { get; set; }
    }
}
