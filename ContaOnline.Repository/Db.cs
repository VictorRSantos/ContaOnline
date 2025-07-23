using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace ContaOnline.Repository
{
    public static class Db
    {
        private static string _conexao = "Server=localhost;Port=3306;Database=contadb;User=root;Password=root;";

        private static MySqlConnection ObterConnection()
        {
            var cn = new MySqlConnection();
            cn.ConnectionString = _conexao;
            return cn;
        }

        public static int Execute(string storeProcedure, object param)
        {
            int total;
            using (var cn = ObterConnection())
            {
                total = cn.Execute(storeProcedure, param, commandType: CommandType.StoredProcedure);
            }

            return total;
        }

        public static T QueryEntidade<T>(string storeProcedure, object param)
        {
            T retorno;
            using (var cn = ObterConnection())
            {
                retorno = cn.QueryFirstOrDefault<T>(storeProcedure, param, commandType:CommandType.StoredProcedure);
            }

            return retorno;
        }

        public static IEnumerable<T> QueryColecao<T>(string storeProcedure, object param)
        {
            IEnumerable<T> retorno;
            using (var cn = ObterConnection())
            {
                retorno = cn.Query<T>(storeProcedure, param, commandType: CommandType.StoredProcedure);
            }

            return retorno;
        }
    }
}
