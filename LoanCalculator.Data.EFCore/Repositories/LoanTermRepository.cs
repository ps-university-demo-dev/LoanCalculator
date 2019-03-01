using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Data.EFCore
{
    public class LoanTermRepository : ILoanTermRepository
    {

        public LoanTermRepository(LoanCalculatorContext context)
        {
            _context = context;
        }

        private LoanCalculatorContext _context;


        public LoanTerm GetLoanTerm(int termYears)
        {
            return _context.LoanTerms.First(loanTerm => loanTerm.Years == termYears);
        }

        public List<LoanTerm> GetLoanTerms()
        {
            return _context.LoanTerms.ToList();
        }
    }
}
