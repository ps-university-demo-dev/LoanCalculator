using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoanCalculator.Core.Domain;
using LoanCalculator.Core.DataInterface;

namespace LoanCalculator.RazorPages.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly IPersonRepository _personRepository;

        public DetailsModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Person { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _personRepository.GetPerson(id.Value);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
