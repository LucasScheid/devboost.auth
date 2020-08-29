using api_dev_boost_auth.Business;
using api_dev_boost_auth.Interfaces;
using api_dev_boost_auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoginController : MainController
    {
        private readonly AppSettings _appSettings;

        public LoginController(IOptions<AppSettings> appSettings, INotificador notificador) : base(appSettings, notificador)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ClientLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientLoginResponse>> RequestAccess([FromBody] ClientLoginRequest clientLoginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                    return CustomResponse(new ClientLoginBLL(_appSettings).AuthenticationRequest(clientLoginRequest));                    
                else
                    return CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
                return CustomResponse();
            }
        }
    }
}
