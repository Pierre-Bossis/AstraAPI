namespace AstraAPI.Models.User
{
    public class RegisterFormDTO
    {
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string? PhotoProfilPath { get; set; }
        public string? PhotoBannierePath { get; set; }

        public string MotDePasse { get; set; }
    }
}
