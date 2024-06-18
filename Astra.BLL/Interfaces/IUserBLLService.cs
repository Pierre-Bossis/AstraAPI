using Astra.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.BLL.Interfaces
{
    public interface IUserBLLService
    {
        void Register(string pseudo, string motDePasse, string email);
        UserEntity Login(string email, string motDePasse);
        IEnumerable<UserEntity> GetId(string pseudo);
        string GetPseudo(string id);
    }
}
