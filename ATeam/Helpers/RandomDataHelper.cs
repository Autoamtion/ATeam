using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Helpers
{
    public static class RandomDataHelper
    {
        private static Random _rand = new Random();

        public static string GetRandomString(int length)
        {
            char[] charArr = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string randomString = string.Empty;
            for (int i = 0; i < length; i++)
            {
                int x = _rand.Next(1, charArr.Length);
                if (!randomString.Contains(charArr.GetValue(x).ToString()))
                {
                    randomString += charArr.GetValue(x);
                }
                else
                {
                    i--;
                }
            }

            return randomString;
        }

        public static string GetRandomNumber(int length)
        {
            string randomNumber = string.Format(
                "{0}{1}{2}",
                _rand.Next(1000000, 9999999),
                _rand.Next(1000000, 9999999),
                _rand.Next(1000000, 9999999));
            return randomNumber.Substring(0, length);
        }

        public static string GetRandomMail()
        {
            return string.Format("AutoTest{0}@{1}.pl", Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10), GetRandomString(5));
        }

        public static string GetRandomNip()
        {
            var nipNumberBuilder = new StringBuilder();
            string taxOfficePrefix = _rand.Next(102,998).ToString();
            nipNumberBuilder.Append(taxOfficePrefix);
            nipNumberBuilder.Append(GenerateRandomNumbers(6));
            int checksum = NipChecksumCalculate(nipNumberBuilder.ToString());
            while (checksum == 10)
            {
                // change last number, check sum must be different from 10
                nipNumberBuilder.Remove(nipNumberBuilder.Length - 1, 1);
                nipNumberBuilder.Append(_rand.Next(10).ToString());
                checksum = NipChecksumCalculate(nipNumberBuilder.ToString());
            }

            nipNumberBuilder.Append(checksum);
            return nipNumberBuilder.ToString();
        }

        private static string GenerateRandomNumbers(int numbersCount)
        {
            int maxValue = (int)Math.Pow(10, numbersCount);
            string format = "D" + numbersCount;
            return _rand.Next(maxValue).ToString(format);
        }

        readonly static int[] _Weight = new[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        public static int NipChecksumCalculate(string nip)
        {
            int checkSum = nip.Zip(_Weight, (digit, weight) => (digit - '0') * weight)
            .Sum();
            return checkSum % 11;
        }
    }
}
