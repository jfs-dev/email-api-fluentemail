using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;

namespace email_api_fluentemail;

public static class FluentEmailService
{
    private static SmtpSender? _sender;

    public static void Initialize(string smtpServer, int smtpPort, string smtpUserName, string smtpPassword)
    {
        _sender = new SmtpSender(() => new SmtpClient(smtpServer)
        {
            Port = smtpPort,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(smtpUserName, smtpPassword)
        });

        Email.DefaultSender = _sender;
    }

    public static SendResponse SendEmail(string from, string to, string subject, string body)
    {
        var email = Email
            .From(from)
            .To(to)
            .Subject(subject)
            .Body(body);

        var result = email.Send();

        return result;
    }
}
