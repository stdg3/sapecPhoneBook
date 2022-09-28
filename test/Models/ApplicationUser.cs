using Microsoft.AspNetCore.Identity;

namespace test.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Contact> MyContact { get; set; }
    }
}
