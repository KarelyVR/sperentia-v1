namespace Sperientia___SGI.Models.Utils.Email
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendChangePasswordEmailAsync(MailChangePasswordRequest request);
    }
}
