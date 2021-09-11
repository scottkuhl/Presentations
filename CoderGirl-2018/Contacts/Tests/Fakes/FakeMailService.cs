using Contacts.Interfaces;
using Contacts.Services;
using System;

namespace Tests.Fakes
{
    public class FakeMailService : IMailService
    {
        public void SendMail(IMail mail)
        {
            Console.WriteLine("Email sent to " + mail.Email);
        }
    }
}