using MailKit.Net.Smtp;
using MimeKit;

namespace ljoy.email
{
    class SendMail
    {
        public SendMail()
        {

        }

        public void EmailVerzenden(string titel, string tekst)
        {
            var message = new MimeMessage();
            var attachment = new MimePart();
            message.From.Add(new MailboxAddress("L-Joy", "app@l-joy.nl"));
            message.To.Add(new MailboxAddress("L-Joy", "app@l-joy.nl"));
            message.Subject = titel;

            message.Body = new TextPart("plain")
            {
                Text = tekst
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.strato.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("app@l-joy.nl", "14-november-1995");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void EmailVerzenden(string titel, string tekst, string email, string gebruikersnaam)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("L-Joy", "app@l-joy.nl"));
            message.To.Add(new MailboxAddress(gebruikersnaam, email));
            message.Subject = titel;

            message.Body = new TextPart("plain")
            {
                Text = tekst
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.strato.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("app@l-joy.nl", "14-november-1995");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
