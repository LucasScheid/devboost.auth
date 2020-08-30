using System.ComponentModel.DataAnnotations;

namespace api_dev_boost_auth.Entities.DataTransferObjects
{
    public class ApontamentoHorasCreationDto
    {
        [Required]
        public string IdentificadorFuncionario { get; set; }

        [Required]
        public int Mes { get; set; }

        [Required]
        public double HorasTrabalhadas { get; set; }
    }
}
