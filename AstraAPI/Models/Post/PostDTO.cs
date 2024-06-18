namespace AstraAPI.Models.Post
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Contenu { get; set; }
        public int Jaime { get; set; }
        public int Partage { get; set; }
        public DateTime DateCreation { get; set; }
        public string User_Pseudo { get; set; }

        public string? Image1 {get;set;}
        public string? Image2 {get;set;}
        public string? Image3 {get;set;}
        public string? Image4 {get;set;}
    }
}
