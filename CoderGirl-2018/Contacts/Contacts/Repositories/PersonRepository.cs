using Contacts.Interfaces;
using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Contacts.Repositories
{
    public interface IPersonRepository
    {
        void AddVisitor(Visitor visitor);

        List<IMail> GetMailable();

        List<Person> GetPeople();
    }

    public class PersonRepository : IPersonRepository
    {
        private List<Customer> _customers;
        private List<Employee> _employees;
        private List<Visitor> _visitors;

        public PersonRepository()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer { FirstName = "Customer", LastName = "1", Phone = "(111) 111-1111" });
            _customers.Add(new Customer { FirstName = "Customer", LastName = "2", Phone = "(222) 222-2222" });

            _employees = new List<Employee>();
            _employees.Add(new Employee { FirstName = "Employee", LastName = "1", Email = "employee1@company.com", Phone = "(333) 333-3333" });
            _employees.Add(new Employee { FirstName = "Employee", LastName = "2", Email = "employee2@company.com", Phone = "(444) 444-4444" });

            _visitors = new List<Visitor>();
            _visitors.Add(new Visitor { FirstName = "Visitor", LastName = "1", Email = "visitor1@home.com" });
            _visitors.Add(new Visitor { FirstName = "Visitor", LastName = "2", Email = "visitor2@home.com" });
        }

        public void AddVisitor(Visitor visitor)
        {
            _visitors.Add(visitor);
            Thread.Sleep(1000);
            Console.WriteLine(visitor.Name + " added to database");
        }

        public List<IMail> GetMailable()
        {
            var people = new List<IMail>();
            people.AddRange(_employees);
            people.AddRange(_visitors);
            return people;
        }

        public List<Person> GetPeople()
        {
            var people = new List<Person>();
            people.AddRange(_customers);
            people.AddRange(_employees);
            people.AddRange(_visitors);
            return people;
        }
    }
}