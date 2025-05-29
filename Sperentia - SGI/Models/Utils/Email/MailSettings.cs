namespace Sperientia___SGI.Models.Utils.Email
{
    public class MailSettings
    {
        public string Mail { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public bool SupportAuthentication { get; set; }
    }
}
