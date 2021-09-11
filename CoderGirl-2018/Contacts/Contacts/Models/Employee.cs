using Contacts.Interfaces;

namespace Contacts.Models
{
    public class Employee : Person, IMail
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
    }
}