using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.DataInterface
{
    public interface IPersonRepository
    {


        List<Person> GetPersons();


        Person GetPerson(int personId);



        void SavePerson(Person person);

    }
}
