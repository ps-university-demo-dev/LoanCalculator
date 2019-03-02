using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoanCalculator.Core.Domain;
using LoanCalculator.Core.DataInterface;

namespace LoanCalculator.RazorPages.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private readonly IPersonRepository _personsRepository;

        public CreateModel(IPersonRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _personsRepository.SavePerson(Person);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}