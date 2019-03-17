using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator.Core.DataInterface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: /<controller>/
        public IActionResult Index(int start, int length = 2, int draw = 1)
        {
            var data = this.repo.GetLoanApplicationResults();
            var recordsTotal = data.Count;

            data = data.Skip(start).Take(length).ToList();

            var response = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };

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
