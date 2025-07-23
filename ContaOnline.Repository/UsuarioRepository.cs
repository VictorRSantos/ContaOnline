using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using Dapper;
using MySql.Data.MySqlClient;   

namespace ContaOnline.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Usuario>("UsuarioObterTodos", null);
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
