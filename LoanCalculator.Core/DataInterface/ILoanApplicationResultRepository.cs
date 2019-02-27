using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.DataInterface
{
    public interface ILoanApplicationResultRepository
    {

        List<LoanApplicationResult> GetLoanApplicationResults();



        void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult);


    }
}
