using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection service = new();
service.AddSingleton<IEmailValidator,EmailValidator>();
service.AddSingleton<IEmailService,EmailService>();
service.AddSingleton<ISmtpService,SmtpService>();
service.AddSingleton<IUserService,UserService>();

ServiceProvider serviceProvider = service.BuildServiceProvider();
var userService = serviceProvider.GetRequiredService<IUserService>();
userService.Register("myEmail@gmail.com","password");

public class User {
    public string? Email {get; private set;}
    public string? Password {get; private set;}
    public User(string email,string password)
    {
        Email = email;
        Password = password;
    }
}
public class MailMessage{
    public string? MyMail {get; private set;}
    public string? ReceiverEmail {get; set;}
    public string? Subject {get;set;}
    public MailMessage(string receiverEmail,string myMail)
    {
        ReceiverEmail = receiverEmail;
        MyMail = myMail;
    }
}
public interface IUserService {
    public void Register(string email, string password);
}
public class UserService : IUserService
{
   private readonly IEmailValidator _emailValidator;
   private readonly IEmailService _emailService;

   public UserService(IEmailValidator emailValidator, IEmailService emailService){
    _emailValidator = emailValidator;
    _emailService = emailService;
   }
   public void Register(string email, string password)
   {
      if (!_emailValidator.ValidateEmail(email))
         throw new ValidationException("Email is not an email");
        
         var user = new User(email, password);
        _emailService.SendEmail(new MailMessage("mysite@nowhere.com",user.Email!) {Subject="Hello foo"});
   }
}
public interface IEmailValidator {
public bool ValidateEmail(string email);
}
public class EmailValidator : IEmailValidator {
    public bool ValidateEmail(string email) {
        return email.Contains("@");
    }
}

public interface IEmailService {
    public void SendEmail(MailMessage message);
}
public class EmailService : IEmailService
{
    private readonly ISmtpService _smtpService;
    public EmailService(ISmtpService smtpService){
    _smtpService = smtpService;
    }
    public void SendEmail(MailMessage message)
    {
      _smtpService.Send(message);
    }
}

public interface ISmtpService {
    public void Send(MailMessage message);
}
public class SmtpService : ISmtpService
{
    public void Send(MailMessage message)
    {
        Console.WriteLine("The message has been sent");
    }
}