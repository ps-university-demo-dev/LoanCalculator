using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public interface ILoanQualificationRule
    {

        String RuleName { get; }

        bool CheckLoanApprovalRule(LoanApplication application);


        
    }
}
