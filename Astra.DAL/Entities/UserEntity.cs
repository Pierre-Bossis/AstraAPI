using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.DAL.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string? PhotoProfilPath { get; set; }
        public string? PhotoBannierePath { get; set; }
        public DateTime DateCreation { get; set; }
        public bool IsAdmin { get; set; }
    }
}
