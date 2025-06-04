using ContaOnline.Domain.Models;

namespace ContaOnline.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPorEmailSenha(string email, string senha);

    }
}
