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
    }
}
