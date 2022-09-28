using Microsoft.AspNetCore.Mvc.Rendering;

namespace test.ViewModel
{
    public class CreateContactViewModel
    {
        public string ContactFirstName { get; set; } = default!;
        public string? ContactLastName { get; set; }
        public string? ContactAdress { get; set; }
    }
}
