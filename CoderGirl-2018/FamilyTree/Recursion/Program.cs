using System;

namespace FamilyTree
{
    static class Program
    {
        static void Main()
        {
            var elizabeth = new FamilyMember { Name = "Elizabeth" };
            var charles = new FamilyMember { Name = "Charles" };
            var anne = new FamilyMember { Name = "Anne" };
            var andrew = new FamilyMember { Name = "Andrew" };
            var edward = new FamilyMember { Name = "Edward" };
            var dianna = new FamilyMember { Name = "Dianna" };
            var camilla = new FamilyMember { Name = "Camilla" };
            var william = new FamilyMember { Name = "William" };
            var henry = new FamilyMember { Name = "Henry" };

            elizabeth.Contacts.Add(charles);
            elizabeth.Contacts.Add(anne);
            elizabeth.Contacts.Add(andrew);
            elizabeth.Contacts.Add(edward);

            charles.Contacts.Add(dianna);
            charles.Contacts.Add(camilla);
            charles.Contacts.Add(william);
            charles.Contacts.Add(henry);

            PrintTree(elizabeth);
            Console.ReadLine();
        }

        static void PrintTree(FamilyMember familyMember)
        {
            Console.WriteLine(familyMember.Name);
            foreach (var innerFamilyMember in familyMember.Contacts)
            {
                PrintTree(innerFamilyMember);
            }
        }
    }
}
