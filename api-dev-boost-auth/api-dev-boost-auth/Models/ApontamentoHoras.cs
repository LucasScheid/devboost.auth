using System.ComponentModel.DataAnnotations;

namespace api_dev_boost_auth.Models
{
    public class ApontamentoHoras
    {
        [Required]
        public string IdentificadorFuncionario { get; set; }

        [Required]
        public int Mes { get; set; }

        [Required]
        public double HorasTrabalhadas { get; set; }

    }
}
