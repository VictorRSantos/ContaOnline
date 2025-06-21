using ContaOnline.Domain.Models;

namespace ContaOnline.Domain.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        IEnumerable<Conta> ObterPorFiltro(ContaFiltro filtro);

    }
}
