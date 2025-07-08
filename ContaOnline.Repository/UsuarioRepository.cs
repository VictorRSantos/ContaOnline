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
            var db = new MySqlConnection();
            db.ConnectionString = "Server=localhost;Port=3306;Database=contadb;User=root;Password=root;";

            //string sql = "SELECT * FROM usuario WHERE usuarioId = @usuarioId";
            string sql = "SELECT * FROM usuario";

            var lista = db.Query<Usuario>(sql, null);

            return lista;
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
