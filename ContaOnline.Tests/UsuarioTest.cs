using ContaOnline.Domain.Models;
using ContaOnline.Repository;

namespace ContaOnline.Tests;

[TestClass]
public class UsuarioTest
{

    [TestMethod]
    public void UsuarioObterTodosTest()
    {
        var rep = new UsuarioRepository();
        var lista = rep.ObterTodos("1");
    }



    [TestMethod]
    public void UsuarioValidarNome()
    {
        // Arrange
        var usuario = new Usuario()
        {
            Email = "teste@test.com.br",
            Id = "1",
            Senha = "123456"
        };

        // Act
        var erros = usuario.Validar();

        // Assert
        Assert.IsTrue(erros.Any());
    }




   
}
