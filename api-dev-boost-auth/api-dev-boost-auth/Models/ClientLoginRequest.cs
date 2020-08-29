using System.ComponentModel.DataAnnotations;

namespace api_dev_boost_auth.Models
{
    public class ClientLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public ClientLoginRequest()
        {
        }
    }
}
