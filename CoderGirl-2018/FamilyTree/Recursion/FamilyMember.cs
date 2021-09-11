using System.Collections.Generic;

namespace FamilyTree
{
    public class FamilyMember
    {
        public string Name { get; set; }
        public List<FamilyMember> Contacts { get; set; }

        public FamilyMember()
        {
            Contacts = new List<FamilyMember>();
        }
    }
}
