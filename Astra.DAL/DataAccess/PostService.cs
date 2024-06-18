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
    public class PostService : IPostRepository
    {
        private readonly DbConnection _connection;

        public PostService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(PostEntity post, List<string> PicturesPath)
        {
            string sql = "INSERT INTO [Post](Contenu,User_Pseudo,Image1,Image2,Image3,Image4) " +
                "VALUES (@contenu,@user_pseudo,@image1,@image2,@image3,@image4); SELECT SCOPE_IDENTITY();";
            int Id = _connection.ExecuteScalar<int>(sql, new { contenu = post.Contenu,user_pseudo = post.User_Pseudo,
                image1 = PicturesPath.Count > 0 ? (object)PicturesPath[0] : DBNull.Value,
                image2 = PicturesPath.Count > 1 ? (object)PicturesPath[1] : DBNull.Value,
                image3 = PicturesPath.Count > 2 ? (object)PicturesPath[2] : DBNull.Value,
                image4 = PicturesPath.Count > 3 ? (object)PicturesPath[3] : DBNull.Value
            });
        }

        public IEnumerable<PostEntity> GetAll()
        {
            string sql = "SELECT * FROM [Post]";
            return _connection.Query<PostEntity>(sql);
        }

        public PostEntity GetOne(int id)
        {
            string sql = "SELECT * FROM [Post] Where Id = @id";
            return _connection.QuerySingleOrDefault<PostEntity>(sql, new { id });
        }
    }
}
