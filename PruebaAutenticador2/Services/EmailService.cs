using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = ""; // Correo origen
        private readonly string _smtpPass = ""; // Contraseña de aplicación (google)

    public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpUser)); // Correo origen (desde)
            email.To.Add(MailboxAddress.Parse(to)); // Correo destino (para)
            email.Subject = subject; // Asunto
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body }; // Cuerpo del correo

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpUser, _smtpPass);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
