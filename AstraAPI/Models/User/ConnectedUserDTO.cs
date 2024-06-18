namespace AstraAPI.Models.User
{
    public class ConnectedUserDTO
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
