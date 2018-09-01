using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    public class Bank
    {
        BankAccountDepartment bankAccountDepartment = BankAccountDepartment.GetBankAccountDepartment();
        ClientDepartment clientDepartment = ClientDepartment.GetClientDepartment();
        LoanDepartment loanDepartment = LoanDepartment.GetLoanDepartment();
        decimal RefinancingRate = 10m;

        public static bool CheckLoanAvailability()
        {
            return false;
        }

        public void Refill()
        {

        }

        public void CashWithdrawal()
        {

        }

        public void ShowBankLoanHistory()
        {
            if (ClientDepartment.ClientBase.Count != 0)
            {
                foreach (KeyValuePair<int, Client> client in ClientDepartment.ClientBase)
                {
                    ClientDepartment.GetClientDepartment().ShowClientLoanHistory(client.Key);
                }
            }
        }

    }
}
