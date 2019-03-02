using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanCalculator.RazorPages.Pages.LoanTerms
{
    public class LoanTermsModel : PageModel
    {

        public LoanTermsModel(ILoanTermRepository loanTermRepository) : base()
        {
            _loanTermRepository = loanTermRepository;
        }

        private ILoanTermRepository _loanTermRepository;

        public List<LoanTerm> LoanTerms { get; private set; }

        public void OnGet()
        {
            LoanTerms = _loanTermRepository.GetLoanTerms();
        }
    }
}