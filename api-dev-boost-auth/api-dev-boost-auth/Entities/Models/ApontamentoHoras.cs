using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_dev_boost_auth.Entities.Models
{
    public class ApontamentoHoras
    {
        [Column("ApontamentoHorasId")]
        public Guid Id { get; set; }

        [Required]
        public string IdentificadorFuncionario { get; set; }

        [Required]
        public int Mes { get; set; }

        [Required]
        public double HorasTrabalhadas { get; set; }

    }
}
