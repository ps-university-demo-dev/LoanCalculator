using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoanCalculator.Core.Domain;
using LoanCalculator.Data.EFCore;
using LoanCalculator.Core.DataInterface;

namespace LoanCalculator.RazorPages.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly IPersonRepository _personRepository;

        public IndexModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IList<Person> Persons { get;set; }

        public void OnGet()
        {
            Persons = _personRepository.GetPersons();
        }
    }
}
