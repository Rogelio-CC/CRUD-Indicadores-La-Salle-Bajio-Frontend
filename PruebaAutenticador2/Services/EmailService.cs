// Importaciones necesarias para el funcionamiento del servicio
using MailKit.Net.Smtp;
using MimeKit;

// Servicio para enviar correos electrónicos utilizando SMTP
public class EmailService
{
    private readonly string _smtpServer = "smtp.gmail.com"; // Servidor SMTP de Gmail
    private readonly int _smtpPort = 587; // Puerto SMTP para conexiones seguras
    private readonly string _smtpUser = ""; // Correo origen
    private readonly string _smtpPass = ""; // Contraseña de aplicación (google)

    // Método para enviar un correo electrónico de forma asíncrona
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var email = new MimeMessage(); // Crear un nuevo mensaje de correo electrónico
        email.From.Add(MailboxAddress.Parse(_smtpUser)); // Correo origen (desde)
        email.To.Add(MailboxAddress.Parse(to)); // Correo destino (para)
        email.Subject = subject; // Asunto
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body }; // Cuerpo del correo

        using var smtp = new SmtpClient();// Crear un nuevo cliente SMTP para enviar el correo
        await smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls); // Conectar al servidor SMTP utilizando TLS para una conexión segura
        await smtp.AuthenticateAsync(_smtpUser, _smtpPass); // Autenticar con el servidor SMTP utilizando las credenciales proporcionadas
        await smtp.SendAsync(email); // Enviar el correo electrónico
        await smtp.DisconnectAsync(true); // Desconectar del servidor SMTP después de enviar el correo
    }
}
