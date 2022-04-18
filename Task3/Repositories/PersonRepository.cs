using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.DataContext;
using Task3.Entities;

namespace Task3.Repositories
{
    public class PersonRepository : IRepository
    {
        private PersonDBContext _context;

        public PersonRepository(PersonDBContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public Person Get(int id)
        {
            var persons = _context.Persons.ToList();
            var person = persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var persons = _context.Persons.ToList();
            return persons;
        }

        public void Update(Person person)
        {
            _context.Entry(person).State =EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
