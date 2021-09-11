using Contacts.Models;
using Contacts.Repositories;
using Contacts.Services;

namespace Contacts.Controller
{
    public class PersonController
    {
        private IMailService _mailService;
        private IPersonRepository _personRepository;

        public PersonController()
        {
            _mailService = new MailService();
            _personRepository = new PersonRepository();
        }

        public PersonController(IMailService mailService, IPersonRepository personRepository)
        {
            _mailService = mailService;
            _personRepository = personRepository;
        }

        public Visitor AddVisitor(string firstName, string lastName, string email)
        {
            var visitor = new Visitor { FirstName = firstName, LastName = lastName, Email = email };

            _personRepository.AddVisitor(visitor);

            _mailService.SendMail(visitor);

            return visitor;
        }
    }
}