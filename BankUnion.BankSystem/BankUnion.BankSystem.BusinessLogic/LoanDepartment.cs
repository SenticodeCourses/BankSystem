using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    class LoanDepartment
    {
        private static LoanDepartment _loanDepartment;
        Dictionary<int, Loan> loanBase = new Dictionary<int, Loan>();

        private LoanDepartment()
        { }

        public static LoanDepartment GetLoanDepartment()
        {
            if (_loanDepartment == null)
            {
                _loanDepartment = new LoanDepartment();
            }
            return _loanDepartment;
        }

        public void CheckLoanBalance()
        {

        }

        public bool CheckLoanAvailability(decimal loanAmount, int clientId)
        {
            int summScore = 0;
            
                if (ClientDepartment.ClientBase.TryGetValue(clientId, out var client))
                {
                    if (client.Age >= 23 && client.Age <= 50)
                    {
                        summScore += 3;
                    }
                    else
                    {
                        summScore += 1;
                    }

                    if (client.AverageWage / loanAmount >= 0.05m)
                    {
                        summScore += 2;
                    }
                    else if (client.AverageWage / loanAmount >= 0.5m)
                    {
                        summScore += 5;
                    }

                    int amountAccount = 0;
                    foreach (var b in client.bankAccount)
                    {
                        
                    }
                }
            
                    return false;
        }

        public void GetLoan()
        {
            if (CheckLoanAvailability() && Bank.CheckLoanAvailability())
            {

            }
        }
    }
}
