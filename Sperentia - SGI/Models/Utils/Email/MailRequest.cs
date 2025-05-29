namespace Sperientia___SGI.Models.Utils.Email
{
    public class MailRequest
    {
        public string ToEmail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public List<IFormFile>? Attachments { get; set; }
    }
}
