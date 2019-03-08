using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class IncomeApprovalRule : ILoanQualificationRule
    {
        public const String RULE_NAME = "Income";
        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(LoanApplication application)
        {
            if (application.LoanAmount < (application.AnnualIncome * 4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
