using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Data.InMemory
{
    public class PersonRepository : IPersonRepository
    {

        public PersonRepository(LoanData data)
        {
            _data = data;
        }


        private LoanData _data;


        public Person GetPerson(int personId)
        {
            return _data.Persons.FirstOrDefault(p => p.PersonId == personId);
        }

        public List<Person> GetPersons()
        {
            return _data.Persons.ToList();
        }


        public void SavePerson(Person person)
        {
            if ( !person.PersonId.HasValue )
            {
                // New Person
                int? maxPersonId = _data.Persons.Max(p => p.PersonId);
                person.PersonId = maxPersonId + 1;
                _data.Persons.Add(person);
            }
            else
            {
                Person existingPersonData = _data.Persons.First(p => p.PersonId == person.PersonId);
                existingPersonData.FirstName = person.FirstName;
                existingPersonData.LastName = person.LastName;
                existingPersonData.AnnualIncome = person.AnnualIncome;
                existingPersonData.CreditScore = person.CreditScore;
            }
        }

    }
}
