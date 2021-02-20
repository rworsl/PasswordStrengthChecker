﻿using System;
using System.Collections.Generic;

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
            if (((CountUppercaseLetters(password) / 2) + (CountLowercaseLetters(password) / 2)) == password.Length)
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
            if ((CountNumbers(password) / 4) == password.Length)
            {
                return password.Length;
            }
            else
            {
                return 0;
            }
        }

        public int checkRepeatCharacters(string password)
        {
            int itemCount = 0;
            List<char> empty = new List<char>();

            var letters = password.ToCharArray();

            foreach (char i in password)
            {
                var counter = 0;
                foreach (char j in letters)
                {
                    if (i == j)
                    {
                        counter += 1;
                    }
                }
                if (counter > 1)
                {
                    empty.Add(i);
                }
            }

            itemCount = empty.Count;

            return itemCount * 2;
        }

        public int ConsecutiveUpperLetters(string password)
        {
            int dupes = 0;
            for (int i = 0; i < password.Length - 1; i++)
            {
                if ((Char.IsUpper(password[i + 1])) && (Char.IsUpper(password[i]) == true))
                {
                    dupes += 1;
                }
            }
            return dupes * 2;
        }

        public int ConsecutiveLowerLetters(string password)
        {
            int dupes = 0;
            for (int i = 0; i < password.Length - 1; i++)
            {
                if ((Char.IsLower(password[i + 1])) && (Char.IsLower(password[i]) == true))
                {
                    dupes += 1;
                }
            }
            return dupes * 2;
        }

        public int ConsecutiveNumbers(string password)
        {
            int dupes = 0;
            for (int i = 0; i < password.Length - 1; i++)
            {
                if ((Char.IsDigit(password[i + 1])) && (Char.IsDigit(password[i]) == true))
                {
                    dupes += 1;
                }
            }
            return dupes * 2;
        }


        public int SequentialLetters(string password)
        {
            int dupes = 0;
            if(password.Length < 2)
            {
                return 0;
            }

            //work out ascii value of each letter and increment it to check the next
            for (int i = 0; i < password.Length - 1; i++)
            {
                if ((Char.IsDigit(password[i + 1])) && (Char.IsDigit(password[i]) == true))
                {
                    dupes += 1;
                }
            }
            return dupes * 2;
        }

    }
}
    /*
    Consecutive Uppercase Letters	Flat	-(n*2)	

    Consecutive Lowercase Letters	Flat	-(n*2)	

    Consecutive Numbers	Flat	-(n*2)	

    Sequential Letters (3+)	Flat	-(n*3)	

    Sequential Numbers (3+)	Flat	-(n*3)	

    Sequential Symbols (3+)
    */

