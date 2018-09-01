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
    }
}
