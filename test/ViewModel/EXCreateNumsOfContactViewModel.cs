using Microsoft.AspNetCore.Mvc.Rendering;

namespace test.ViewModel
{
    public class EXCreateNumsOfContactViewModel
    {
        public string NumsOfContactNumber { get; set; }
        public int SelectedTypeId { get; set; }
        public List<SelectListItem>? ListOfTypes{ get; set; }
    }
}
