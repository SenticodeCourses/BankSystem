using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    public class Loan
    {
        public int Id;
        int ClientId;

        public decimal SumLoan;
        public decimal PaidAmount;

        
        public Dictionary<DateTime, decimal> RepaymentHistory = new Dictionary<DateTime, decimal>(); 

        public void UpdateRepaymentHistory(decimal sum)
        {
            RepaymentHistory.Add(DateTime.Now, sum);
        }

    }
}
