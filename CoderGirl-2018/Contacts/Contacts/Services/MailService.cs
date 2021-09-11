using Contacts.Interfaces;
using System;
using System.Threading;

namespace Contacts.Services
{
    public interface IMailService
    {
        void SendMail(IMail mail);
    }

    public class MailService : IMailService
    {
        public void SendMail(IMail mail)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Email sent to " + mail.Email);
        }
    }
}