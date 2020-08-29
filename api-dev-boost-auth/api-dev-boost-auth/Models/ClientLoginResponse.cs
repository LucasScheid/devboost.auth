using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Models
{
    public class ClientLoginResponse
    {
        public bool Authenticated { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }

        public ClientLoginResponse()
        {
        }
    }
}
