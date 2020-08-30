using api_dev_boost_auth.Entities.DataTransferObjects;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
