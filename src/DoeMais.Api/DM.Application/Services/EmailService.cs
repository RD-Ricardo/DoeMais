using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace DM.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> EnviarEmail(string emailDestinatario, string caminhoAnexo = null)
        {
            try
            {
                MailMessage mail = new();

                mail.From = new MailAddress(_configuration["EmailConfig:Email"]);
                mail.To.Add(emailDestinatario);
                mail.Subject = "Doe mais relatório"; 
                mail.Body = "Relatório movimentação estoque de sangue.";

                if (caminhoAnexo is not null)
                {
                    Attachment anexo = new(caminhoAnexo, MediaTypeNames.Application.Pdf);
                    mail.Attachments.Add(anexo);
                }

                using (var smtp = new SmtpClient("smtp-mail.outlook.com"))
                {
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false; 

                    smtp.Credentials = new NetworkCredential(_configuration["EmailConfig:Email"], _configuration["EmailConfig:Senha"]);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
