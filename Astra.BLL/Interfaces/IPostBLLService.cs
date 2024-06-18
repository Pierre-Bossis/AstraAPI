using Astra.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.BLL.Interfaces
{
    public interface IPostBLLService
    {
        void Create(PostEntity post, List<string>PicturesPath);
        PostEntity GetOne(int id);
        IEnumerable<PostEntity> GetAll();
    }
}
