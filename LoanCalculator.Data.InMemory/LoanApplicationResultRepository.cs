using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Data.InMemory
{
    public class LoanApplicationResultRepository : ILoanApplicationResultRepository
    {

        public LoanApplicationResultRepository(LoanData data)
        {
            _data = data;
        }


        private LoanData _data;


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
