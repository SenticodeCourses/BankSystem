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
=======

>>>>>>> 4cfcba900c5ba0dc05c4f85dad2d319c2cffc72b
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
        

        public void GetLoan(decimal sumLoan, int ClientId)
        {
<<<<<<< HEAD
        }
        Dictionary<int, Loan> loanBase = new Dictionary<int, Loan>();
=======

            if (CheckLoanAvailability(sumLoan, ClientId) && Bank.CheckLoanAvailability(sumLoan))
            {

            if (CheckLoanAvailability() && Bank.CheckLoanAvailability())
            {


            }
        }

        Dictionary<int, Loan> loanBase = new Dictionary<int, Loan>();

>>>>>>> 4cfcba900c5ba0dc05c4f85dad2d319c2cffc72b
    }
}
