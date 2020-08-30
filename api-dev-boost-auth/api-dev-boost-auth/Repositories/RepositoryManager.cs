using api_dev_boost_auth.Contracts;
using api_dev_boost_auth.Entities;
using System.Threading.Tasks;

namespace api_dev_boost_auth.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IApontamentoHorasRepository _apontamentoHorasRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IApontamentoHorasRepository ApontamentoHoras
        {
            get
            {
                if (_apontamentoHorasRepository == null)
                    _apontamentoHorasRepository = new ApontamentoHorasRepository(_repositoryContext);

                return _apontamentoHorasRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }
}
