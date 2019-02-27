using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Data.InMemory
{
    public class LoanTermRepository : ILoanTermRepository
    {
        public LoanTermRepository(LoanData data)
        {
            _data = data;
        }


        private LoanData _data;


        public LoanTerm GetLoanTerm(int loanTerm)
        {
            return _data.LoanTerms.FirstOrDefault(t => t.Years == loanTerm);
        }

        public List<LoanTerm> GetLoanTerms()
        {
            return _data.LoanTerms.ToList();
        }
    }
}
