namespace Console1
{
  using System;
  using System.Net;
  using System.Net.Mail;
  using Ninject;

  class Program
  {
    static void Main()
    {
      using (var kernel = new StandardKernel())
      {
        var service = kernel.Get<SalutationService>();
        service.SayHello();
      }

      using (var kernel = new StandardKernel())
      {
        kernel.Bind<ILogger>().To<ConsoleLogger>();
        var mailService = kernel.Get<MailService>();
        mailService.SendMail("asas", "asas", "asasasaa");
      }

        Console.WriteLine("Presss Enter to exit...");
      Console.ReadLine();
    }
  }

  class SalutationService
  {
    public void SayHello()
    {
      Console.WriteLine("Hello, World from Ninject1");
    }
  }

  interface ILogger
  {
    void Log(string message);
  }

  class ConsoleLogger : ILogger
  {
    public void Log(string message)
    {
      Console.WriteLine("{0}: {1}", DateTime.Now, message);
    }
  }

  class MailServerConfig
  {
    public string SmtpServer { get; } = "smtp server - get this from config file";
    public int SmtpPort { get; } = 25;
    public string SenderEmail { get; } = "sender email -get this from config file";
    public string SenderPassword { get; } = "sender password - get this from config file";

  }

  class MailService
  {
    private readonly ILogger _logger;
    // ReSharper disable once NotAccessedField.Local
    private readonly SmtpClient _client;

    public MailService(MailServerConfig config, ILogger logger)
    {
      _logger = logger;
      _client = InitializeClient(config);
    }

    private SmtpClient InitializeClient(MailServerConfig config) => new SmtpClient
    {
      Host = config.SmtpServer,
      Port = config.SmtpPort,
      EnableSsl = true,
      Credentials = new NetworkCredential
      {
        UserName = config.SenderEmail,
        Password = config.SenderPassword
      }
    };

    public void SendMail(string address, string subject, string body)
    {
      _logger.Log("Initializing...");
      // initialize mail
      _logger.Log("Sending mail...");
      _logger.Log("Mail sent successfully...");
    }
  }
}
