namespace Exadel.Requests
{
    public class LoginResponse
    {
        public string? Username { get; set; }
        public string? AccessToken { get; set; }
        public int EpiresIn { get; set; }  
    }
}
