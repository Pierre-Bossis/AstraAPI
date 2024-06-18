using Astra.BLL.Interfaces;
using Astra.DAL.Entities;
using Astra.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.BLL.Services
{
    public class PostBLLService : IPostBLLService
    {
        private readonly IPostRepository _repo;

        public PostBLLService(IPostRepository repo)
        {
            _repo = repo;
        }
        public void Create(PostEntity post, List<string> PicturesPath)
        {
            _repo.Create(post, PicturesPath);
        }

        public IEnumerable<PostEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public PostEntity GetOne(int id)
        {
            return _repo.GetOne(id);
        }
    }
}
