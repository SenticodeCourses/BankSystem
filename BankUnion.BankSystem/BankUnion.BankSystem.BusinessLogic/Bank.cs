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

  }
}
