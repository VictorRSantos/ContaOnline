using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using static System.Net.Mime.MediaTypeNames;

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

        IEnumerable<ContaListItem> IContaRepository.ObterPorFiltro(ContaFiltro filtro)
        {
            return Db.QueryColecao<ContaListItem>("ContaObterListagemPorFiltro", filtro);
        }
    }
}
