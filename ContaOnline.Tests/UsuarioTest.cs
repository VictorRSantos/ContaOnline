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

    [TestMethod]
    public void UsuarioIncluirTeste()
    {
        // Arrange
        var usuario = new Usuario()
        {
            Id = "2",
            Nome = "TesteRep2",
            Email = "testerep2@email.com",
            Senha = "123456"
        };

        // act
        var repositorio = new UsuarioRepository();
        repositorio.Incluir(usuario);
    }

    [TestMethod]
    public void UsuarioAlterarTeste()
    {
        // Arrange
        var usuario = new Usuario()
        {
            Id = "1",
            Nome = "TesteRepAlterado",
            Email = "testerepalterado@email.com",
            Senha = "123456"
        };

        // act
        var repositorio = new UsuarioRepository();
        repositorio.Alterar(usuario);
    }

    [TestMethod]
    public void UsuarioExcluirTest()
    {
        // Arrange
        var usuario = new Usuario() { Id = "1" };

        // act
        var repositorio = new UsuarioRepository();
        repositorio.Excluir(usuario.Id);

    }

    [TestMethod]
    public void UsuarioObterPorIdTest()
    {
        // Arrange
        var usuario = new Usuario() { Id = "1" };

        // act
        var repositorio = new UsuarioRepository();
        var retorno = repositorio.ObterPorId(usuario.Id);

        // Assert
        Assert.IsNotNull(retorno);
        Assert.AreEqual(usuario.Id, retorno.Id);
    }

    [TestMethod]
    public void UsuarioObterPorEmailSenhaTest()
    {
        // Arrange
        var usuario = new Usuario()
        {
            Email = "testerep2@email.com",
            Senha = "123456"
        };

        // act
        var repositorio = new UsuarioRepository();
        var retorno = repositorio.ObterPorEmailSenha(usuario.Email, usuario.Senha);

        // Assert
        Assert.IsNotNull(retorno);
        Assert.AreEqual(usuario.Email, retorno.Email);
        Assert.AreEqual(usuario.Senha, retorno.Senha);
    }

}
