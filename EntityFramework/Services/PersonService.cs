using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Person> Read()
        {
            List<Person> people = new List<Person>();

            if (_context.People.Count() != 0)
            {
                people = _context.People.ToList();
            }

            return people;
        }

        public Person Read(int id)
        {
            return _context.People.Find(id);
        }

        public Person Create(CreatePersonViewModel createPersonVM)
        {
            Person newPerson = new Person()
            {
                FirstName = createPersonVM.FirstName,
                LastName = createPersonVM.LastName,
                City = createPersonVM.City
            };

            _context.People.Add(newPerson);
            _context.SaveChanges();

            return newPerson;
        }

        public bool Remove(int id)
        {
            Person original = Read(id);

            if(original == null)
            {
                return false;
            }

            _context.People.Remove(original);
            _context.SaveChanges();

            return true;
        }
    }
}
