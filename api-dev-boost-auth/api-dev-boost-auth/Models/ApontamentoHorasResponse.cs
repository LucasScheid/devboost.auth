using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Models
{
    public class ApontamentoHorasResponse
    {
        public string IdentificadorFuncionario { get; set; }
       
        public int Mes { get; set; }
       
        public double HorasTrabalhadas { get; set; }

        public DateTime DataRegistro { get; set; }
    }
}
