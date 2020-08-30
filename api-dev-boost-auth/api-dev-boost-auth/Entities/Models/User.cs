using Microsoft.AspNetCore.Identity;

namespace api_dev_boost_auth.Entities.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
