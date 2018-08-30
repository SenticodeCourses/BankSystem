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

    public bool CheckLoanAvailability()
    {

      return false;
    }

    public void GetLoan()
    {
      if(CheckLoanAvailability() && Bank.CheckLoanAvailability())
      {

      }

    }
  }
}
