using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    class Client
    {
        public int Id;
        public List<int> loan = new List<int>();
        public List<int> bankAccount = new List<int>();
    }
}
