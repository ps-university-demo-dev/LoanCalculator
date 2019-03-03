using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using LoanCalculator.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoanCalculator.RazorPages.Util;

namespace LoanCalculator.RazorPages.Pages.NewLoan
{
    public class CreateModel : PageModel
    {

        public CreateModel(LoanProcessingService loanProcessingService,  ILoanApplicationResultRepository resultRepository)
        {
            _loanProcessingService = loanProcessingService;            
            //_loanTermRepository = loanTermRepository;
            _resultRepository = resultRepository;
        }

        private LoanProcessingService _loanProcessingService;
        //private ILoanTermRepository _loanTermRepository;
        private ILoanApplicationResultRepository _resultRepository;

        public IList<SelectListItem> Persons { get; private set; }

        public IList<SelectListItem> LoanTerms { get; private set; }


        [BindProperty]
        public LoanApplication LoanApplication { get; set; }

        [BindProperty]
        public int TermYears { get; set; }


        public IActionResult OnGet()
        {
            LoanTerms = LoanTerm.LoanTerms.Values
                .OrderBy(t => t.Years)
                .ToSelectList(t => t.Years.ToString(), t => t.Name);

            return Page();
        }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var loanTerm = LoanTerm.GetLoanTerm(TermYears);           
            LoanApplication.Term = loanTerm;

            var result = _loanProcessingService.ProcessLoan(LoanApplication);
            _resultRepository.SaveLoanApplicationResult(result);


            return RedirectToPage($"./LoanApplicationResult", new { id = result.ResultId });
        }

    }
}