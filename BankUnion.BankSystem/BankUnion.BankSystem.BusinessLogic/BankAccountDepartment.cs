using System.Collections.Generic;

namespace BankUnion.BankSystem.BusinessLogic
{
    class BankAccountDepartment
    {
        private static BankAccountDepartment _bankAccountDepartment;
        public static Dictionary<string, BankAccount> BankAccountBase = new Dictionary<string, BankAccount>();
        public Dictionary<BankAccount, Client> AccountClientDict { get; } = new Dictionary<BankAccount, Client>();

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

        public void CreateBankAccount(Client client)
        {
            var bankAcc = new BankAccount {ClientId = client.Id};
            BankAccountBase.Add(bankAcc.Id, bankAcc);
            client.bankAccount.Add(bankAcc.InternalId);
            AccountClientDict.Add(bankAcc, client);
        }

        public void DeleteBankAccount(string id)
        {
            AccountClientDict[BankAccountBase[id]].bankAccount.Remove(BankAccountBase[id].InternalId);
            AccountClientDict.Remove(BankAccountBase[id]);
            BankAccountBase.Remove(id);
        }

        public void Refill(string id, decimal sum)
        {
            BankAccountBase[id].Balance += sum;
        }

        public void CashWithdrawal(string id, decimal sum)
        {
            if (sum >= BankAccountBase[id].Balance)
                BankAccountBase[id].Balance -= sum;
        }

        public decimal CheckBalance(string id)
        {
            return BankAccountBase[id].Balance;
        }
    }
}


//8. Реализовать метод регистрации счетов, добавления их в список клиента, 
//метод удаления счетов и метод проверки баланса.

//BankAccountDepartment:
//- CreateBankAccount(), создание нового счёта, занесение в базу и добавление клиенту Id данного счёта.
//- DeleteBankAccount(), удаление указанного счёта из базы и из списка счетов у клиента.
//- Refill(), зачисление денежной суммы на счёт.
//- CashWithdrawal(), снятие денег со счёта.


//Сущность Client содержит List<int> bankAccount, с указанием в нём Id счетов клиента.


