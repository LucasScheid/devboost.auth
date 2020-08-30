using api_dev_boost_auth.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Contracts
{
    public interface IApontamentoHorasRepository
    {
        Task<IEnumerable<ApontamentoHoras>> GetAllApontamentoHorasAsync(bool trackChanges);
        Task<ApontamentoHoras> GetApontamentoHorasAsync(Guid apontamentoHorasId, bool trackChanges);
        void CreateApontamentoHoras(ApontamentoHoras apontamentoHoras);
        Task<IEnumerable<ApontamentoHoras>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteApontamentoHoras(ApontamentoHoras apontamentoHoras);
    }
}
