﻿using System;
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

        public IndexModel(ILoanApplicationResultRepository loanResultRepository, ILoanRateRepository rateRepo)
        {
            _loanResultRepository = loanResultRepository;
            _loanRateRepository = rateRepo;
        }


        private ILoanApplicationResultRepository _loanResultRepository;
        private ILoanRateRepository _loanRateRepository;

        public List<LoanApplicationResult> LoanApplicationResults { get; set; }

        public List<LoanRate> LoanRates { get; set; }

        public void OnGet()
        {
            LoanApplicationResults = _loanResultRepository.GetLoanApplicationResults();
            LoanRates = _loanRateRepository.GetLoanRates().Take(3).ToList();
        }
    }
}
