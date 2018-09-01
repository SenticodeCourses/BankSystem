using System;
using System.Linq;
using System.Text;

namespace BankUnion.BankSystem.BusinessLogic
{
    class BankAccount
    {
        public string Id { get; }
        // ReSharper disable once RedundantDefaultMemberInitializer
        private static int _stId = 0;
        public int InternalId { get; }
        public int ClientId { get; set; }
        public decimal Balance;

        public BankAccount()
        {
            _stId++;
            InternalId = _stId;
            Id = FormatId(_stId);
        }

        public static string FormatId(int stId)
        {
            const int digitsNumber = 16;
            var id = new StringBuilder().Append(Convert.ToString(stId));
                id.Insert(0, Enumerable.Range(1, digitsNumber - id.Length)
                    .Select(i => '0').ToString());
            return id.ToString();
        }
    }
}
