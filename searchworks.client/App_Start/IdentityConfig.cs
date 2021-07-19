using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using searchworks.client.Models;
using MailKit;
using MimeKit;
using System.Net.Configuration;
using System.Configuration;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace searchworks.client
{
    public class EmailService : IIdentityMessageService
    {
        public   Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("JCred ", smtpSection.From));
            mailMessage.To.Add(new MailboxAddress(message.Destination, message.Destination));
            mailMessage.Subject = message.Subject;

            mailMessage.Body = new TextPart("html")
            {
                Text = message.Body
            };
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(smtpSection.Network.Host, smtpSection.Network.Port, smtpSection.Network.EnableSsl);
                smtpClient.Authenticate(smtpSection.Network.UserName, smtpSection.Network.Password);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
            return Task.FromResult(true);

            /*
            var smtp = new MailKit.Net.Smtp.SmtpClient();
            var mail = new MimeMessage();
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string username = smtpSection.Network.UserName;

            //mail.IsBodyHtml = true;
            mail.From.Add(new MailboxAddress(username, username));// = new MailAddress(username);
            mail.To.Add(new MailboxAddress(message.Destination, message.Destination));
            mail.Subject = "JCred Notification : "+message.Subject;
            mail.Body = new TextPart(TextFormat.Html) { Text = message.Body }; 

            

            try {
                smtp.Timeout = 1000;
                await smtp.ConnectAsync(smtpSection.Network.Host, smtpSection.Network.Port, SecureSocketOptions.Auto);
                await smtp.AuthenticateAsync(smtpSection.Network.UserName, smtpSection.Network.Password);
                await smtp.SendAsync(mail);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception err)
            {

            }
            */

            //return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
