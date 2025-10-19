using ContaOnline.Domain.Models;
using ContaOnline.Repository;

namespace ContaOnline.Tests
{
    [TestClass]
    public class ContaCorrenteTests
    {
        ContaCorrenteRepository _repository = new ContaCorrenteRepository();


        [TestMethod]
        public void ContaCorrenteIncluirTest()
        {
            var contaCorrente = new ContaCorrente()
            {
                Id = "1",
                Descricao = "Conta Corrente Teste",
                UsuarioId = "1"
            };

            _repository.Incluir(contaCorrente);
        }

        [TestMethod]
        public void ContaCorrenteAlterarTest()
        {
            var contaCorrente = new ContaCorrente()
            {
                Id = "1",
                Descricao = "Conta Corrente Teste Alterada",
                UsuarioId = "1"
            };
            _repository.Alterar(contaCorrente);
        }

        [TestMethod]
        public void ContaCorrenteObterTodosTest()
        {
            var contaCorrente = _repository.ObterTodos("1");
        }

        [TestMethod]
        public void ContaCorrenteObterPorIdTest()
        {
            var contaCorrente = _repository.ObterPorId("1");
        }

        [TestMethod]
        public void ContaCorrenteExcluir()
        {
            _repository.Excluir("1");
        }
    }
}
