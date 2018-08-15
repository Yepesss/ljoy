using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

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
            message.From.Add(new MailboxAddress("L-Joy", "ljoydancefactoryapp@gmail.com"));
            message.To.Add(new MailboxAddress("L-Joy", "ljoydancefactoryapp@gmail.com"));
            message.Subject = titel;

            message.Body = new TextPart("plain")
            {
                Text = tekst
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("ljoydancefactoryapp@gmail.com", "ljoy1234");

                client.Send(message);
                client.Disconnect(true);
            }
        }

                public void EmailVerzenden(string titel, string tekst, string email, string gebruikersnaam)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("L-Joy", "ljoydancefactoryapp@gmail.com"));
            message.To.Add(new MailboxAddress(gebruikersnaam, email));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("ljoydancefactoryapp@gmail.com", "ljoy1234");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
