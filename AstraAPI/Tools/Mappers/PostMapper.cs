using Astra.DAL.Entities;
using AstraAPI.Models.Post;
using AstraAPI.Models.User;

namespace AstraAPI.Tools.Mappers
{
    public static class PostMapper
    {
        public static PostDTO ToDto(this PostEntity e)
        {
            if (e is not null)
            {
                string img1 = string.Empty;
                string img2 = string.Empty;
                string img3 = string.Empty;
                string img4 = string.Empty;

                if (!string.IsNullOrEmpty(e.Image1) && File.Exists(e.Image1))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Image1);
                    img1 = Convert.ToBase64String(imageBytes);
                }

                if (!string.IsNullOrEmpty(e.Image2) && File.Exists(e.Image2))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Image2);
                    img2 = Convert.ToBase64String(imageBytes);
                }

                if (!string.IsNullOrEmpty(e.Image3) && File.Exists(e.Image3))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Image3);
                    img3 = Convert.ToBase64String(imageBytes);
                }

                if (!string.IsNullOrEmpty(e.Image4) && File.Exists(e.Image4))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Image4);
                    img4 = Convert.ToBase64String(imageBytes);
                }

                return new PostDTO
                {
                    Id = e.Id,
                    Contenu = e.Contenu,
                    Jaime = e.Jaime,
                    Partage = e.Partage,
                    DateCreation = e.DateCreation,
                    User_Pseudo = e.User_Pseudo,
                    Image1 = img1,
                    Image2 = img2,
                    Image3 = img3,
                    Image4 = img4,
                };
            }
            return null;
        }

        public static PostEntity ToBLL(this PostFormDTO dto)
        {
            if (dto is not null)
            {

                return new PostEntity
                {
                    Contenu = dto.Contenu,
                    User_Pseudo = dto.User_Pseudo
                };
            }
            return null;
        }
    }
}
