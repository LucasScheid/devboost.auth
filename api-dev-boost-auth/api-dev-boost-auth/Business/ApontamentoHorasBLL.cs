using api_dev_boost_auth.Models;
using System;

namespace api_dev_boost_auth.Business
{
    public class ApontamentoHorasBLL
    {
        private readonly AppSettings _appSettings;

        public ApontamentoHorasBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public ApontamentoHorasResponse RegistrarHoras(ApontamentoHoras apontamentoHoras)
        {
            ApontamentoHorasResponse apontamentoHorasResponse = new ApontamentoHorasResponse
            {
                IdentificadorFuncionario = apontamentoHoras.IdentificadorFuncionario,
                Mes = apontamentoHoras.Mes,
                HorasTrabalhadas = apontamentoHoras.HorasTrabalhadas,
                DataRegistro = DateTime.Now
            };

            return apontamentoHorasResponse;
        }
    }
}
