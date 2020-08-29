using System;

namespace api_dev_boost_auth.Models
{
    public class SSOUser
    {
        public SSOUser()
        {
        }

        public int Id { get; set; }      
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string JobRole { get; set; }
              
    }
}
