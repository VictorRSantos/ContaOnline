using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;

namespace ContaOnline.Repository
{
    public class ContaRepository : IContaRepository
    {
        public void Alterar(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conta> ObterPorFiltro(ContaFiltro filtro)
        {
            throw new NotImplementedException();
        }

        public Conta ObterPorId(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
