using Astra.DAL.Entities;
using Astra.DAL.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.DAL.DataAccess
{
    public class UserService : IUserRepository
    {
        private readonly DbConnection _connection;

        public UserService(DbConnection connection)
        {
            _connection = connection; ;
        }
        public string CheckPassword(string email)
        {
            string sql = "SELECT MotDePasse FROM [User] WHERE Email = @email";
            return _connection.QueryFirst<string>(sql, new { email });
        }

        public IEnumerable<UserEntity> GetId(string pseudo)
        {
            string sql = "SELECT Id, Pseudo FROM [User] WHERE Pseudo LIKE '%' + @pseudo + '%'";
            IEnumerable<UserEntity> results = _connection.Query<UserEntity>(sql, new { pseudo });
            return results;
        }

        public string GetPseudo(string id)
        {
            string sql = "SELECT Pseudo FROM [User] WHERE Id = @id";
            return _connection.QueryFirst<string>(sql, new { id });
        }

        public UserEntity Login(string email)
        {
            string sql = "SELECT * FROM [User] WHERE Email = @email";

            return _connection.QueryFirst<UserEntity>(sql, new { email });
        }

        public void Register(string pseudo, string motDePasse, string email)
        {
            string sql = "INSERT INTO [User] (Pseudo,Email,MotDePasse)" +
                "VALUES(@pseudo,@email,@motDePasse)";

            _connection.Execute(sql, new { pseudo, email, motDePasse });
        }
    }
}
