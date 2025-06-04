using System.Collections.Generic;

namespace ContaOnline.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Incluir(T entidade);
        void Alterar(T entidade);
        void Excluir(string id);
        T ObterPorId(string id);
        IEnumerable<T> ObterTodos();
    }
}
