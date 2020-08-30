using api_dev_boost_auth.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace api_dev_boost_auth.Entities.Configuration
{
    public class ApontamentoHorasConfiguration : IEntityTypeConfiguration<ApontamentoHoras>
    {
        public void Configure(EntityTypeBuilder<ApontamentoHoras> builder)
        {
            builder.HasData
            (
                new ApontamentoHoras
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    HorasTrabalhadas = 50,
                    Mes = 4,
                    IdentificadorFuncionario = "Funcionario 1"
                },
                new ApontamentoHoras
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    HorasTrabalhadas = 168,
                    Mes = 5,
                    IdentificadorFuncionario = "Funcionario 1"
                }
            );
        }
    }
}
