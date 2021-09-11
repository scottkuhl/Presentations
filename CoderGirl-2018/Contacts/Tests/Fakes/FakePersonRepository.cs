using Contacts.Interfaces;
using Contacts.Models;
using Contacts.Repositories;
using System;
using System.Collections.Generic;

namespace Tests.Fakes
{
    public class FakePersonRepository : IPersonRepository
    {
        private List<Customer> _customers;
        private List<Employee> _employees;
        private List<Visitor> _visitors;

        public FakePersonRepository()
        {
            _customers = new List<Customer>();

            _employees = new List<Employee>();

            _visitors = new List<Visitor>();
        }

        public void AddVisitor(Visitor visitor)
        {
            _visitors.Add(visitor);
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