using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator.Core.DataInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculatorMvc.Controllers
{
    public class LoanRatesController : Controller
    {


        public LoanRatesController(ILoanRateRepository loanRateRepository)
        {
            _loanRateRepository = loanRateRepository;
        }


        private ILoanRateRepository _loanRateRepository;


        // GET: LoanRates
        public ActionResult Index()
        {

            var rates = _loanRateRepository.GetLoanRates();

            return View(rates);
        }

    }
}