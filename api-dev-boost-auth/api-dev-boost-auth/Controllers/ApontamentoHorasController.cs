using api_dev_boost_auth.Contracts;
using api_dev_boost_auth.Entities.DataTransferObjects;
using api_dev_boost_auth.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Controllers
{
    [Route("api/apontamento-horas")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ApontamentoHorasController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public ApontamentoHorasController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "CreateApontamentoHoras")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateApontamentoHoras([FromBody] ApontamentoHorasCreationDto apontamentoCreationDto)
        {
            ApontamentoHoras apontamentoHoras = new ApontamentoHoras
            {
                Id = Guid.NewGuid(),
                HorasTrabalhadas = apontamentoCreationDto.HorasTrabalhadas,
                IdentificadorFuncionario = apontamentoCreationDto.IdentificadorFuncionario,
                Mes = apontamentoCreationDto.Mes
            };

            _repository.ApontamentoHoras.CreateApontamentoHoras(apontamentoHoras);
            await _repository.SaveAsync();

            return CreatedAtRoute("ApontamentoHorasById", new { id = apontamentoHoras.Id }, apontamentoHoras);
        }

        [HttpGet("{id}", Name = "ApontamentoHorasById")]
        public async Task<IActionResult> GetApontamentoHoras(Guid id)
        {
            var apontamentoHoras = await _repository.ApontamentoHoras.GetApontamentoHorasAsync(id, trackChanges: false);

            if (apontamentoHoras == null)
                return NotFound();
            else
                return Ok(apontamentoHoras);
        }

        [HttpGet(Name = "BuscarTodosApontamentoHoras"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> BuscarTodosApontamentoHoras()
        {
            var apontamentoHoras = await _repository.ApontamentoHoras.GetAllApontamentoHorasAsync(trackChanges: false);
            return Ok(apontamentoHoras.ToList());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteApontamento(Guid id)
        {
            var apontamento = await _repository.ApontamentoHoras.GetApontamentoHorasAsync(id, trackChanges: true);

            if (apontamento != null)
            {
                _repository.ApontamentoHoras.DeleteApontamentoHoras(apontamento);
                await _repository.SaveAsync();
            }

            return NoContent();
        }
    }
}
