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
<<<<<<< HEAD
        public static Dictionary<int, Loan> LoanBase = new Dictionary<int, Loan>();

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

                decimal amountAccount = 0m;
                foreach (var b in client.bankAccount)
                {
                    if (BankAccountDepartment.BankAccountBase.TryGetValue(b, out var bankAccount))
                    {
                        amountAccount += bankAccount.Balance;
                    }
                }
                if (amountAccount >= 0.25m)
                {
                    summScore += 3;
                }

                if (!client.IsFatallyIll)
                {
                    summScore += 1;
                }

                if (!client.IsHasCriminalRecord)
                {
                    summScore += 1;
                }

                if (client.IsHasHigherEducation)
                {
                    summScore += 2;
                }

                if (client.IsHasMinorChildren)
                {
                    summScore += 1;
                }

                if (client.IsHasRealState)
                {
                    summScore += 3;
                }

                decimal loanTotal = 0m;
                foreach (var c in client.loan)
                {
                    if (LoanBase.TryGetValue(c, out var loanSum))
                    {
                        loanTotal += loanSum.SumLoan - loanSum.PaidAmount;
                    }
                }
                if (client.AverageWage / loanTotal > 0.05m)
                {
                    summScore += 2;
                }

                if (client.Sex == SexEnum.female)
                {
                    summScore += 1;
                }
            }

            if (summScore >= 12)
            {
                return true;
            }

            return false;
        }

        public void GetLoan(decimal sumLoan, int ClientId)
        {
            if (CheckLoanAvailability(sumLoan, ClientId) && Bank.CheckLoanAvailability(sumLoan))
            {

            }
        }
=======
        Dictionary<int, Loan> loanBase = new Dictionary<int, Loan>();
>>>>>>> DatabaseStorage
    }
}
