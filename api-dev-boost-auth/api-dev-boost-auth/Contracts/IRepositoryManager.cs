using System.Threading.Tasks;

namespace api_dev_boost_auth.Contracts
{
    public interface IRepositoryManager
    {
        IApontamentoHorasRepository ApontamentoHoras { get; }
        Task SaveAsync();
    }
}
