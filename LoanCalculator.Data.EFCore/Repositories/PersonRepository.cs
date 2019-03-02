using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanCalculator.Data.EFCore
{
    public class PersonRepository : IPersonRepository
    {

        public PersonRepository(LoanCalculatorContext context)
        {
            _context = context;
        }

        private LoanCalculatorContext _context;


        public Person GetPerson(int personId)
        {
            return _context.Persons.First(p => p.PersonId == personId);
        }

        public List<Person> GetPersons()
        {
            return _context.Persons.ToList(); ;
        }

        public void SavePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
    }
}
