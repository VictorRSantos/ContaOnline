using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;

namespace ContaOnline.Domain.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        ContaExibirViewModel ObterExibirPorId(string id);
        IEnumerable<ContaListItem> ObterPorUsuario(string usuarioId);
        IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro);
    }
}
