namespace Contacts.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FirstName))
                    return LastName;
                if (string.IsNullOrWhiteSpace(LastName))
                    return FirstName;
                return FirstName + " " + LastName;
            }
        }
    }
}