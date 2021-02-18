using System;

namespace PasswordStrengthChecker
{
    public class Program
    {
        int strengthScore = 0;

        string Password1 = "sdadafsdyhgasgdfqw";
        string Password2 = "SdadaFsdyhgasGdfqwe";
        string Password3 = "1234";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfCharacters(string password)
        {
            return (password.Length * 4);
        }

        public int CountUppercaseLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i])) count++;
            }

            if (count == 0)
            {
                return 0;
            }
            else
            {
                return (password.Length - count) * 2;
            }
        }

        public int CountLowercaseLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i])) count++;
            }

            if (count == 0)
            {
                return 0;
            }
            else
            {
                return (password.Length - count) * 2;
            }
        }

        public int CountNumbers(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i])) count++;
            }
            return count * 4;
        }

        public int CountSymbols(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLetterOrDigit(password[i])) count++;
            }

            return (password.Length - count) * 6;
        }

        public int CountMiddleSymbols(string password)
        {
            var symbols = 0;
            int count = 0;
            for (int i = 1; i < password.Length - 1; i++)
            {
                if (char.IsLetterOrDigit(password[i])) symbols++;
            }

            for (int i = 1; i < password.Length - 1; i++)
            {
                if (char.IsDigit(password[i])) count++;
            }
            var total = (password.Length - 2) - symbols;
            total += count;

            return total * 2;
        }

        public int MeetsAllRequirements(string password)
        {
            int total = 0;
            if (CountUppercaseLetters(password) > 0)
            {
                total += 1;
            }
            if (CountLowercaseLetters(password) > 0)
            {
                total += 1;
            }
            if (CountNumbers(password) > 0)
            {
                total += 1;
            }
            if (CountSymbols(password) > 0)
            {
                total += 1;
            }
            if (password.Length > 7)
            {
                total += 1;
            }
            return total * 2;
        }

        public int onlyLetters(string password)
        {
            if ((CountUppercaseLetters(password) + CountLowercaseLetters(password)) == password.Length)
            {
                return password.Length;
            }
            else
            {
                return 0;
            }
        }

        public int onlyNumbers(string password)
        {
            if (CountNumbers(password) == password.Length)
            {
                return password.Length;
            }
            else
            {
                return 0;
            }
        }
    }
}
