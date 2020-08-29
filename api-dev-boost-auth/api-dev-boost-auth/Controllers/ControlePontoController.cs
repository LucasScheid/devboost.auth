using api_dev_boost_auth.Business;
using api_dev_boost_auth.Interfaces;
using api_dev_boost_auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace api_dev_boost_auth.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ControlePontoController : MainController
    {
        private readonly AppSettings _appSettings;

        public ControlePontoController(IOptions<AppSettings> appSettings, INotificador notificador) : base(appSettings, notificador)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        [ProducesResponseType(typeof(ApontamentoHorasResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ApontamentoHorasResponse> RegistrarHoras([FromBody] ApontamentoHoras apontamentoHoras)
        {
            try
            {
                if (ModelState.IsValid)
                    return CustomResponse((new ApontamentoHorasBLL(_appSettings).RegistrarHoras(apontamentoHoras)));
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
