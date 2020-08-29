using api_dev_boost_auth.Interfaces;
using api_dev_boost_auth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Linq;

namespace api_dev_boost_auth.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly INotificador _notificador;

        protected MainController(IOptions<AppSettings> appSettings, INotificador notificador)
        {
            _appSettings = appSettings.Value;
            _notificador = notificador;
        }

        protected bool ValidOperation()
        {
            return !_notificador.HaveNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.GetNotifications().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelError(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                ReportError(errorMsg);
            }
        }

        protected void ReportError(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }
    }
}
