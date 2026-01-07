using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;

namespace ContaOnline.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        public void Alterar(Contato contato)
        {
            Db.Execute("ContatoAlterar", contato);
        }

        public void Excluir(string id)
        {
            Db.Execute("ContatoExcluir", new {Id = id });
        }

        public void Incluir(Contato contato)
        {
            Db.Execute("ContatoIncluir", contato);
        }

        public Contato ObterPorId(string id)
        {
            return Db.QueryEntidade<Contato>("ContatoObterPorId", new {Id = id});
        }

        public IEnumerable<Contato> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Contato>("ContatoObterTodos", new {usuarioId = usuarioId});
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
