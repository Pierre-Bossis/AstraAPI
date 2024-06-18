using System.ComponentModel.DataAnnotations;

namespace AstraAPI.Models.Post
{
    public class PostFormDTO
    {
        [Required]
        public string Contenu { get; set; }
        public string User_Pseudo { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }
        public IFormFile? Image4 { get; set; }

    }
}
