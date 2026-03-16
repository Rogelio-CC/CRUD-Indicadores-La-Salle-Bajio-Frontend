// Importaciones necesarias para el funcionamiento del servicio
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

// Servicio para enviar correos electrónicos utilizando SMTP
public class EmailService
{
    private readonly string _smtpServer; // Servidor SMTP de Gmail
    private readonly int _smtpPort; // Puerto SMTP para conexiones seguras
    private readonly string _smtpUser; // Correo origen
    private readonly string _smtpPass; // Contraseña de aplicación (google)

    public EmailService(IConfiguration config)
    {
        // Lee configuración desde variables de entorno o secretos (IConfiguration combina fuentes)
        _smtpServer = config["Email:SmtpServer"] ?? "smtp.gmail.com";
        _smtpPort = int.TryParse(config["Email:SmtpPort"], out var p) ? p : 587;
        _smtpUser = config["Email:SmtpUser"] ?? string.Empty;
        _smtpPass = config["Email:SmtpPass"] ?? string.Empty;
    }

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

        // Solo autenticar si se proporcionó usuario
        if (!string.IsNullOrEmpty(_smtpUser))
        {
            await smtp.AuthenticateAsync(_smtpUser, _smtpPass); // Autenticar con el servidor SMTP utilizando las credenciales proporcionadas
        }
        
        await smtp.SendAsync(email); // Enviar el correo electrónico
        await smtp.DisconnectAsync(true); // Desconectar del servidor SMTP después de enviar el correo
    }
}
