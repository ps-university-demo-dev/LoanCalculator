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
    public class IndexModel : PageModel
    {

        public IndexModel(ILoanApplicationResultRepository loanResultRepository)
        {
            _loanResultRepository = loanResultRepository;
        }


        private ILoanApplicationResultRepository _loanResultRepository;

        public List<LoanApplicationResult> LoanApplicationResults { get; set; }

        public void OnGet()
        {
            LoanApplicationResults = _loanResultRepository.GetLoanApplicationResults();
        }
    }
}
