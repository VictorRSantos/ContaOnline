using ContaOnline.Domain.Models;

namespace ContaOnline.Tests;

[TestClass]
public class UsuarioTest
{
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
