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
            return (password.Length - count) * 2;
        }
    }
}
