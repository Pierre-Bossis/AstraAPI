using Astra.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.DAL.Repositories
{
    public interface IPostRepository
    {
        void Create(PostEntity post, List<string> PicturesPath);
        PostEntity GetOne(int id);
        IEnumerable<PostEntity> GetAll();
    }
}
