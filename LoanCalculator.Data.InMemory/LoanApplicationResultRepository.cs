using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Data.InMemory
{
    public class LoanApplicationResultRepository : ILoanApplicationResultRepository
    {
        public List<LoanApplicationResult> GetLoanApplicationResults()
        {
            throw new NotImplementedException();
        }

        public void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult)
        {
            throw new NotImplementedException();
        }
    }
}
