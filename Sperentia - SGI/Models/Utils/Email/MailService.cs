using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Sperientia___SGI.Models.Utils.Email
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }


        public async Task SendChangePasswordEmailAsync(MailChangePasswordRequest request)
        {
            // Traemos el archivo de la plantilla
            string FilePath = Directory.GetCurrentDirectory() + "\\ArchivosPrivados\\PlantillasCorreos\\CorreoCambioContrasena.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            // Sustituimos los datos de la plantilla por los de la Confirmacion
            MailText = MailText.Replace("[NombreCompleto]", request.NombreCompleto);
            MailText = MailText.Replace("[PaginaTokenURL]", request.Token);
            // Sustituimos los datos generales de la plantilla
            // No hay

            // Preparamos todo para enviar el correo
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(request.CorreoDestino));
            email.Subject = $"Reestablecer contraseña";
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();

            // Enviamos el correo
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
            if (_mailSettings.SupportAuthentication)
            {
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            }
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
