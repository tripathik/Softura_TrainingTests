using Microsoft.Extensions.Logging;
using PersonDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDetails.Services
{
    public class PersonManager : IRepo<Person>
    {
        private PersonContext _context;
        private ILogger<PersonManager> _logger;
        public PersonManager(PersonContext context, ILogger<PersonManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Person t)
        {
            try
            {
                _context.Persons.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Person t)
        {
            try
            {
                _context.Persons.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Person Get(int id)
        {
            try
            {
                Person person = _context.Persons.FirstOrDefault(a => a.Id == id);
                return person;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                if (_context.Persons.Count() == 0)
                    return null;
                return _context.Persons;
                    
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Person t)
        {
            Person person = Get(id);
            if (person != null)
            {
                person.Id = t.Id;
                person.Name = t.Name;
                person.Age = t.Age;
                person.Qualification= t.Qualification;
                person.IsEmployeed = t.IsEmployeed;
                person.NoticePeriod = t.NoticePeriod;
                person.CurrentCTC = t.CurrentCTC;
            }
            _context.SaveChanges();
        }
    }
}
