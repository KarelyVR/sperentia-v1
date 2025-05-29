namespace Sperientia___SGI.Models.Utils.Email
{
    public class MailChangePasswordRequest
    {
        public string CorreoDestino { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
