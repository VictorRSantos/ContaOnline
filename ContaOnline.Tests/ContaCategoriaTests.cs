using ContaOnline.Domain.Models;
using ContaOnline.Repository;

namespace ContaOnline.Tests
{
    [TestClass]
    public class ContaCategoriaTests
    {
        ContaCategoriaRepository _repository = new ContaCategoriaRepository();

        [TestMethod]
        public void IncluirTest()
        {
            var conta = new ContaCategoria()
            {
                Id = "12345",
                Nome = "Categoria Teste",
                UsuarioId = "abc"
            };

            _repository.Incluir(conta);
        }

        [TestMethod]
        public void AlterarTest()
        {
            var conta = new ContaCategoria()
            {
                Id = "12345",
                Nome = "Categoria Teste Alterada",
                UsuarioId = "abc"
            };
            _repository.Alterar(conta);
        }

        [TestMethod]
        public void ExcluirTest()
        {
            _repository.Excluir("12345");
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var lista = _repository.ObterTodos("abc");
        }


        [TestMethod]
        public void ObterPorIdTest()
        {
            var conta = _repository.ObterPorId("1");
        }

    }
}
