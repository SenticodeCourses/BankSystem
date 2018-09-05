using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankUnion.BankSystem.BusinessLogic.Authorization;

namespace BankUnion.BankSystem.BusinessLogic
{
    public enum SexEnum
    {
        male,
        female,
        unknown
    }
    class Client 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public SexEnum Sex { get; set; }
        public int Age { get; set; }
        public bool IsFatallyIll { get; set; }
        public bool IsHasRealState { get; set; }
        public decimal AverageWage { get; set; }
        public bool IsHasMinorChildren { get; set; }
        public bool IsHasHigherEducation { get; set; }
        public bool IsHasCriminalRecord { get; set; }
        public Account Account { get; set; }

        public List<int> loan = new List<int>();
        public List<string> bankAccount = new List<string>();
    }
}
