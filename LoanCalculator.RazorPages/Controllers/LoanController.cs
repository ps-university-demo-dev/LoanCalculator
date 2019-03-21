using LoanCalculator.Core.DataInterface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LoanCalculator.RazorPages.Controllers
{
    public class LoanController : Controller
    {
        private ILoanApplicationResultRepository repo;

        public LoanController(ILoanApplicationResultRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("loans")]
        public IActionResult Index(int start, int length = 2, int draw = 1)
        {
            var loanResults = this.repo.GetLoanApplicationResults();
            var totalRecords = loanResults.Count;

            loanResults = loanResults.Skip(start).Take(length).ToList();

            var response = new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = loanResults };

            return Ok(response);
        }

        [HttpGet("loans/{id}")]
        public IActionResult Index(int id)
        {
            var loan = this.repo.GetLoanApplicationResult(id);
            return View(loan);
        }
    }
}
