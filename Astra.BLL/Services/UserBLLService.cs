using Astra.BLL.Interfaces;
using Astra.DAL.Entities;
using Astra.DAL.Repositories;
using Crypt = BCrypt.Net;

namespace Astra.BLL.Services
{
    public class UserBLLService : IUserBLLService
    {
        private readonly IUserRepository _repo;

        public UserBLLService(IUserRepository repo)
        {
            _repo = repo;
        }
        public UserEntity Login(string email, string motDePasse)
        {
            string pwdToCheck = _repo.CheckPassword(email);
            if (Crypt.BCrypt.Verify(motDePasse, pwdToCheck))
            {
                return _repo.Login(email);
            }
            throw new InvalidOperationException("Email ou mot de passe incorrect");
        }

        public void Register(string pseudo, string motDePasse, string email)
        {
            string hash = Crypt.BCrypt.HashPassword(motDePasse);

            _repo.Register(pseudo, hash, email);
        }

        public IEnumerable<UserEntity> GetId(string pseudo)
        {
            return _repo.GetId(pseudo);
        }

        public string GetPseudo(string id)
        {
            return _repo.GetPseudo(id);
        }
    }
}
