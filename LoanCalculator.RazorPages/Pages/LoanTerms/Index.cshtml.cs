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
        private ILoanRateRepository _loanRateRepository;

        public LoanTermsModel(ILoanRateRepository loanRateRepository) : base()
        {
            this._loanRateRepository = loanRateRepository;
        }

        public List<LoanTerm> LoanTerms { get; private set; }

        public List<LoanRate> LoanRates { get; private set; }


        public void OnGet()
        {
            LoanRates = this._loanRateRepository.GetLoanRates();

            LoanTerms = LoanTerm.LoanTerms.Values
                .OrderBy(t => t.Years)
                .ToList() ;
        }
    }
}