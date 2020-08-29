using api_dev_boost_auth.Data;
using api_dev_boost_auth.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_dev_boost_auth.Business
{
    public class ClientLoginBLL
    {
        private readonly AppSettings _appSettings;

        public ClientLoginBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public ClientLoginResponse AuthenticationRequest(ClientLoginRequest clientLoginRequest)
        {
            try
            {
                ClientLoginResponse clientLoginResponse = new ClientLoginResponse();

                var clientLoginDAL = new ClientLoginDAL();

                var ssoUser = clientLoginDAL.GetSSOUser(clientLoginRequest.UserName, clientLoginRequest.Password);

                if (ssoUser != null)
                {
                    clientLoginResponse.Authenticated = true;
                    clientLoginResponse.CreationDate = DateTime.Now;
                    clientLoginResponse.ExpirationDate = DateTime.Now.AddHours(Convert.ToInt32(_appSettings.ExpirationHours));
                    clientLoginResponse.AccessToken = GerarJwt(ssoUser);
                    clientLoginResponse.Message = "OK!";
                }
                else
                {
                    clientLoginResponse.Authenticated = false;
                    clientLoginResponse.CreationDate = null;
                    clientLoginResponse.ExpirationDate = null;
                    clientLoginResponse.Message = "Authentication Failure.";
                }

                return clientLoginResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GerarJwt(SSOUser ssoUser)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _appSettings.Emitter,
                    Audience = _appSettings.ValidOn,

                    Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, ssoUser.Identifier.ToString()),
                        new Claim(ClaimTypes.Role, ssoUser.JobRole.ToString())
                        }),

                    Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                });

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
