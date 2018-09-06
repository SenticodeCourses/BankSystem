using System;

namespace BankUnion.BankSystem.BusinessLogic
{
    public static class Iban
    {
        public static string Generate(string id)
        {
            var countryCode = "BY";
            var bankBic = "BNKU";
            var balanceAcc = "3092";
            var checksum = GetChecksum();
            return countryCode + checksum + bankBic + balanceAcc + id;
        }

        private static string GetChecksum()
        {
            var rand = new Random();
            var checksum = rand.Next(1, 99).ToString();
            if (checksum.Length == 1)
                checksum = "0" + checksum;
            return checksum;
        }
    }
}
