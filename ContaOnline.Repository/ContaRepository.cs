using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;

namespace ContaOnline.Repository
{
    public class ContaRepository : IContaRepository
    {
        public void Alterar(Conta conta)
        {
            Db.Execute("ContaAlterar", conta);
        }

        public void Excluir(string id)
        {
            Db.Execute("ContaExcluir", new { Id = id });
        }

        public void Incluir(Conta conta)
        {
            Db.Execute("ContaIncluir", conta);
        }

        public ContaExibirViewModel ObterExibirPorId(string id)
        {
            return Db.QueryEntidade<ContaExibirViewModel>("ContaObterExibirPorId", new { ContaId = id });
        }

        public Conta ObterPorId(string id)
        {
            return Db.QueryEntidade<Conta>("ContaObterPorId", new { Id = id });
        }

        public IEnumerable<ContaListItem> ObterPorUsuario(string usuarioId)
        {
            return Db.QueryColecao<ContaListItem>("ContaObterTodos", new { UsuarioId = usuarioId });
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Conta>("ContaObterTodos", new { UsuarioId = usuarioId });
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro)
        {
            if (filtro.DataInicial == null) filtro.DataInicial = DateTime.MinValue;
            if (filtro.DataFinal == null) filtro.DataFinal = DateTime.MaxValue;

            var lista = Db.QueryColecao<ContaListItem>("ContaObterEntreDatas", new { DataInicial = filtro.DataInicial, DataFinal = filtro.DataFinal, IdUsuario = filtro.UsuarioId }).ToList();

            var listaFiltrada = lista.ToList();
            if (filtro.ContaCorrenteId != null)
            {
                listaFiltrada = listaFiltrada.Where(x => x.ContaCorrenteId == filtro.ContaCorrenteId).ToList();

            }
            
            if (filtro.CategoriaId != null)
            {
                listaFiltrada = listaFiltrada.Where(x => x.CategoriaId == filtro.CategoriaId).ToList();
            }

            return listaFiltrada;

        }
    }
}
