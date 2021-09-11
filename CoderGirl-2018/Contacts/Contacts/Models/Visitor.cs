using Contacts.Interfaces;

namespace Contacts.Models
{
    public class Visitor : Person, IMail
    {
        public string Email { get; set; }
    }
}