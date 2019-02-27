using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Data.InMemory
{

    public class LoanRateRepository : ILoanRateRepository
    {

        public LoanRateRepository(LoanData data)
        {
            _data = data;
        }


        private LoanData _data;

        public List<LoanRate> GetLoanRates()
        {
            return _data.LoanRates.ToList();
        }
    }
}
