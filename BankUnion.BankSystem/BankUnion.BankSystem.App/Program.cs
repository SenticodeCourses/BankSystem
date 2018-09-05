using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankUnion.BankSystem.BusinessLogic;

namespace BankUnion.BankSystem.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientBase = new Dictionary<int, Client>
            {
                [21] = new Client(),
                [1] = new Client(),
                [2] = new Client(),
                [3] = new Client(),
                [4] = new Client(),
                [5] = new Client(),
                [6] = new Client()
            };

            var loanBase = new Dictionary<int, Loan>
            {
                [21] = new Loan(),
                [1] = new Loan(),
                [2] = new Loan(),
                [3] = new Loan(),
                [4] = new Loan(),
                [5] = new Loan(),
                [6] = new Loan(),
            };

            var bankAccountBase = new Dictionary<int, BankAccount>
            {
                [21] = new BankAccount(),
                [1] = new BankAccount(),
                [2] = new BankAccount(),
                [3] = new BankAccount(),
                [4] = new BankAccount(),
                [5] = new BankAccount(),
                [6] = new BankAccount(),
            };

            var dbManager = new DatabaseManager();

            dbManager.SaveDatabase(clientBase);
            dbManager.SaveDatabase(bankAccountBase);
            dbManager.SaveDatabase(loanBase);
            
            dbManager.DelTuple<Client>(21);
            dbManager.UpdateDB<Client>(228);

            dbManager.ShowDatabase(typeof(Client));
            dbManager.ShowDatabase(typeof(BankAccount));
            dbManager.ShowDatabase(typeof(Loan));

            Console.ReadLine();
        }
    }
}
