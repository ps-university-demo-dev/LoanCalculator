using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanCalculator.RazorPages.Pages
{
    public class LoanRatesModel : PageModel
    {


        public LoanRatesModel(ILoanRateRepository loanRateRepository) : base()
        {
            _loanRateRepository = loanRateRepository;
        }

        private ILoanRateRepository _loanRateRepository;


        public List<LoanRate> LoanRates { get; private set; }


        public void OnGet()
        {
            LoanRates = _loanRateRepository.GetLoanRates();
        }
    }
}