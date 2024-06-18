using Astra.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.DAL.Repositories
{
    public interface IUserRepository
    {
        string CheckPassword(string email);
        UserEntity Login(string email);
        void Register(string pseudo, string motDePasse, string email);
        IEnumerable<UserEntity> GetId(string pseudo);
        string GetPseudo(string id);
    }
}
