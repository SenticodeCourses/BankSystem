using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    public class Client
    {
        public int Id;
        public string FullName;
        public bool IsFatallyIll;
        public bool IsHasRealState;
        public SexEnum Sex;
        public decimal AverageWage;
        public int Age;
        public bool IsHasMinorChildren;
        public bool IsHasHigherEducation;
        public bool IsHasCriminalRecord;

        public List<int> loan = new List<int>();
        public List<string> bankAccount = new List<string>();
    }

    public enum SexEnum
    {
        male,
        female
    }
}
