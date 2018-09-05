using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    class  ClientDepartment : IDisposable
    {
        private static ClientDepartment _clientDepartment;
        public static Dictionary<int, Client> ClientBase = new Dictionary<int, Client>();

        private ClientDepartment()
        { }

        public static ClientDepartment GetClientDepartment()
        {
            if (_clientDepartment == null)
            {
                _clientDepartment = new ClientDepartment();
            }
            return _clientDepartment;
        }

        public void RegisterClient()
        {

        }

        public void CheckLoanHistory()
        {

        }

        public void Dispose()
        {

        }

        //method for repaying in cash
        public bool RepayLoan(decimal sum, int loanId)
        {
            if (LoanDepartment.LoanBase.TryGetValue(loanId, out var loan))
            {
                loan.PaidAmount += sum;
                loan.UpdateRepaymentHistory(sum);
                return true;
            }
            return false;
        }

        //method for repaying using money from account
        public bool RepayLoan(decimal sum, int loanId, string bankAccountId)
        {
            if (BankAccountDepartment.BankAccountBase.TryGetValue(bankAccountId, out var bankAccount))
            {
                if (bankAccount.Balance < sum)
                    return false;
                bankAccount.Balance -= sum;
                RepayLoan(sum, loanId);
                return true;
            }
            return false;            
        }

        public void ShowClientLoanHistory(int clientId)
        {
            if (ClientDepartment.ClientBase.TryGetValue(clientId, out var client))
            {
                Console.WriteLine(client.FullName);
                foreach (int loanId in client.loan)
                {
                    Loan loan = LoanDepartment.LoanBase[loanId];
                    Console.WriteLine("ID: " + loan.Id);
                    Console.WriteLine("Сумма кредита: " + loan.SumLoan);
                    Console.WriteLine("Уплачено: " + loan.PaidAmount);
                    Console.WriteLine("История платежей: ");
                    foreach (KeyValuePair<DateTime, decimal> kvp in loan.RepaymentHistory)
                    {
                        Console.WriteLine(kvp.Key + " " + kvp.Value);
                    }
                }
            }

        }
    }
}
