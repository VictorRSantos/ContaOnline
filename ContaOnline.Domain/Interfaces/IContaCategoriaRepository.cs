using ContaOnline.Domain.Models;
using System.Collections.Generic;

namespace ContaOnline.Domain.Interfaces
{
    public interface IContaCategoriaRepository
    {
        void Incluir(ContaCategoria contaCategoria);
        void Alterar(ContaCategoria contaCategoria);
        void Excluir(string id);
        ContaCategoria ObterPorId(string id);
        IEnumerable<ContaCategoria> ObterTodos();
    }
}
