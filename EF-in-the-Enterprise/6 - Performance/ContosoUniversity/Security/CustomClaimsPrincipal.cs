using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace ContosoUniversity.Security
{
    public class CustomClaimsPrincipal : ClaimsPrincipal
    {
        public CustomClaimsPrincipal(string userName)
        {
            // Create the identity.
            GenericIdentity gi = new GenericIdentity(userName, "Contoso Univerity Custom Authentication");
            ClaimsIdentity ci = new ClaimsIdentity(gi);

            SchoolContext context = new SchoolContext();

            // Lookup the user name in the database.
            var person = new GenericRepository<Person>(context).Get().Where(p => p.UserName == userName).FirstOrDefault();
            if (person != null)
            {
                // Map claim values.
                ci.AddClaim(new Claim(ClaimTypes.Name, person.FullName));
                ci.AddClaim(new Claim(ClaimTypes.WindowsAccountName, person.UserName));
                ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, person.Email));
                ci.AddClaim(new Claim(ClaimTypes.Email, person.Email));
            }

            // Add claim role for instructor.
            var instructor = new GenericRepository<Instructor>(context).Get().Where(p => p.UserName == userName).FirstOrDefault();
            if (instructor != null)
                ci.AddClaim(new Claim(ClaimTypes.Role, "Instructor"));

            // Add claim role for student.
            var student = new GenericRepository<Student>(context).Get().Where(p => p.UserName == userName).FirstOrDefault();
            if (student != null)
                ci.AddClaim(new Claim(ClaimTypes.Role, "Student"));

            // Add the identity.
            this.AddIdentity(ci);
        }
    }
}