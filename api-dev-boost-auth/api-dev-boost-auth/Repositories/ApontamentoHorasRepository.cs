using api_dev_boost_auth.Contracts;
using api_dev_boost_auth.Entities;
using api_dev_boost_auth.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Repositories
{
    public class ApontamentoHorasRepository : RepositoryBase<ApontamentoHoras>, IApontamentoHorasRepository
    {
        public ApontamentoHorasRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateApontamentoHoras(ApontamentoHoras apontamentoHoras) => Create(apontamentoHoras);
       
        public void DeleteApontamentoHoras(ApontamentoHoras apontamentoHoras)
        {
            Delete(apontamentoHoras);
        }

        public async Task<IEnumerable<ApontamentoHoras>> GetAllApontamentoHorasAsync(bool trackChanges) =>
         await FindAll(trackChanges)
         .OrderBy(c => c.IdentificadorFuncionario)
         .ToListAsync();

        public async Task<ApontamentoHoras> GetApontamentoHorasAsync(Guid apontamentoHorasId, bool trackChanges) =>
           await FindByCondition(c => c.Id.Equals(apontamentoHorasId), trackChanges)
           .SingleOrDefaultAsync();

        public async Task<IEnumerable<ApontamentoHoras>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
          await FindByCondition(x => ids.Contains(x.Id), trackChanges)
          .ToListAsync();
    }
}
