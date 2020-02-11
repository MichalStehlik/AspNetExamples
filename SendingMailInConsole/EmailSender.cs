using MimeKit;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace SendingMailInConsole
{
    class EmailSender // :  IEmailSender
    // https://github.com/jstedfast/MailKit
    // https://docs.microsoft.com/cs-cz/dotnet/api/microsoft.aspnetcore.identity.ui.services.iemailsender.sendemailasync?view=aspnetcore-3.0
    // https://mailtrap.io/
    {
        private string _fromName = "IronMan";
        private string _from = "iron@stark.com";
        private int _port = 2525;
        private string _server = "smtp.mailtrap.io";
        private string _userName = "xxxxxxxxxxx";
        private string _password = "xxxxxxxxxxx";

        /*
        public IConfiguration Configuration { get; protected set; }

        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
            _fromName = Configuration["EmailSender:FromName"];
            _from = Configuration["EmailSender:From"];
            _port = Configuration["EmailSender:Port"];
            _server = Configuration["EmailSender:Server"];
            _userName = Configuration["EmailSender:Username"];
            _password = Configuration["EmailSender:Password"];
        }
        */

        public Task SendEmailAsync(string emailAddress, string subject, string text)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _from));
            message.To.Add(new MailboxAddress(emailAddress));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = text;
            bodyBuilder.HtmlBody = "<p style=\"color: red;\">" + text + "</p>";
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_server, _port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                client.Authenticate(_userName, _password);
                client.Send(message);
                client.Disconnect(true);
                return Task.FromResult(0);
            }
        }

        // Google:
        // https://www.google.com/settings/security/lesssecureapps & set to "Turn On"
        // client.Connect("smtp.gmail.com", 587);
        // client.AuthenticationMechanisms.Remove("XOAUTH2");
        // client.Authenticate(_userName, _password);

    }
}
