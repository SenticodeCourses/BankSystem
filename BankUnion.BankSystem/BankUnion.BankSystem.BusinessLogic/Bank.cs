using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    class Bank
    {
        BankAccountDepartment bankAccountDepartment = BankAccountDepartment.GetBankAccountDepartment();
        ClientDepartment clientDepartment = ClientDepartment.GetClientDepartment();
        LoanDepartment loanDepartment = LoanDepartment.GetLoanDepartment();
        decimal RefinancingRate = 10m;
        static BankAccount _accountOfBank = new BankAccount();

        public static bool CheckLoanAvailability(decimal loanAmount)
        {
            decimal totalBankLoan = 0;
            foreach (var l in LoanDepartment.LoanBase.Values)
            {
                totalBankLoan += l.SumLoan - l.PaidAmount;
            }

            if ((totalBankLoan + loanAmount) < _accountOfBank.Balance * 9)
            {
                return true;
            }

            return false;
        }

        public void Refill()
        {

        }

        public void CashWithdrawal()
        {

        }

    }
}
