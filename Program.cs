using email_api_fluentemail;

var smtpServer = "smtp.dominio.com.br";
var smtpPort = 587;
var smtpUserName = "seu-email@dominio.com.br";
var smtpPassword = "sua senha forte";

FluentEmailService.Initialize(smtpServer, smtpPort, smtpUserName, smtpPassword);

var from = "seu-email@dominio.com.br";
var to = "destinatario@dominio.com.br";
var subject = "Teste de e-mail usando FluentEmail";
var body = "Este é um exemplo de e-mail enviado usando FluentEmail.";

var result = FluentEmailService.SendEmail(from, to, subject, body);

if (result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("E-mail enviado com sucesso.");
}
else
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Falha ao enviar o e-mail!");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nErros:");

    foreach (var errorMessage in result.ErrorMessages)
    {
        Console.WriteLine(errorMessage);
    }    
}
