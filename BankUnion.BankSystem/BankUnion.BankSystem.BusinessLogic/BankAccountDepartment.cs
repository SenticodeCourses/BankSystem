using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    class BankAccountDepartment
    {
        private static BankAccountDepartment _bankAccountDepartment;
        public static Dictionary<string, BankAccount> BankAccountBase = new Dictionary<string, BankAccount>();

        private BankAccountDepartment()
        { }

        public static BankAccountDepartment GetBankAccountDepartment()
        {
            if (_bankAccountDepartment == null)
            {
                _bankAccountDepartment = new BankAccountDepartment();
            }
            return _bankAccountDepartment;
        }

        public void CreateBankAccount()
        {

        }

        public void DeleteBankAccount()
        {

        }

        public void Refill()
        {

        }

        public void CashWithdrawal()
        {

        }
    }
}
