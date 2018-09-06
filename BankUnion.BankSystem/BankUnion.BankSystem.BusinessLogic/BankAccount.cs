using System;
using System.Linq;

namespace BankUnion.BankSystem.BusinessLogic
{
    public class BankAccount
    {
        public string Id { get; }
        // ReSharper disable once RedundantDefaultMemberInitializer
        private static int _stId = 0;
        public int ClientId { get; set; }
        public decimal Balance;

        public BankAccount()
        {
            _stId++;
            Id = Iban.Generate(TransformIdToString(_stId));
        }

        public static string TransformIdToString(int stId)
        {
            const int digitsNumber = 16;
            var id = Convert.ToString(stId);
            return Enumerable.Range(1, digitsNumber - id.Length)
                     .Select(i => '0')+ id;
        }
    }
}
