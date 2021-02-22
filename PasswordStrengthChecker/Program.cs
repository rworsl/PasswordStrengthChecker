using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            int total = 0;
            string password = "SullenCitadelTwiddlingCosigner";

            var Program = new Program();

            total += Program.NumberOfCharacters(password);
            //max 200
            Console.WriteLine(Program.NumberOfCharacters(password));
            
            //max 400
            total += Program.CountUppercaseLetters(password);
            Console.WriteLine(Program.CountUppercaseLetters(password));
            
            //max 100
            total += Program.CountLowercaseLetters(password);
            Console.WriteLine(Program.CountLowercaseLetters(password));
            
            //max 50
            total += Program.CountNumbers(password);
            Console.WriteLine(Program.CountNumbers(password));
            
            //max 50
            total += Program.CountSymbols(password);
            Console.WriteLine(Program.CountSymbols(password));
            
            //max 50
            total += Program.CountMiddleSymbols(password);
            Console.WriteLine(Program.CountMiddleSymbols(password));
            total += Program.MeetsAllRequirements(password);
            
            //max 10
            Console.WriteLine(Program.MeetsAllRequirements(password));
            total -= Program.onlyLetters(password);
            
            //Max possible = 860


            //max 200
            Console.WriteLine(Program.onlyLetters(password));
            total -= Program.onlyNumbers(password);
            
            //max 200
            Console.WriteLine(Program.onlyNumbers(password));
            total -= Program.checkRepeatCharacters(password);
            
            //max 50
            Console.WriteLine(Program.checkRepeatCharacters(password));

            //max 50
            total -= Program.ConsecutiveUpperLetters(password);

            //max 50
            total -= Program.ConsecutiveLowerLetters(password);
            
            //max 50
            total -= Program.ConsecutiveNumbers(password);

            //max 50
            Console.WriteLine(Program.SequentialLetters(password));


            Console.WriteLine(total);
        }

        public int NumberOfCharacters(string password)
        {
            if (password.Length * 4 > 200)
            {
                return 100;
            }
            else
            {
                return (password.Length * 4);
            }
        }

        public int CountUppercaseLetters(string password)
        {
            int count = 0;
            foreach (char i in password)
            {
                if (char.IsUpper(i)) count += 1;
            }

            if (count == 0)
            {
                return 0;
            }
            else
            {
                if (((password.Length - count) * 2) > 400)
                {
                    return 50;
                }
                else
                {
                    return (password.Length - count) * 2;
                }
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
                if (((password.Length - count) * 2) > 100)
                {
                    return 100;
                }
                else
                {
                    return (password.Length - count) * 2;
                }
            }
        }

        public int CountNumbers(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i])) count++;
            }
            
            if (count * 4 > 50)
            {
                return 50;
            }
            else
            {
                return count * 4;
            }
        }

        public int CountSymbols(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLetterOrDigit(password[i])) count++;
            }

            if (((password.Length - count) * 6) > 50)
            {
                return 50;
            }
            else
            {
                return (password.Length - count) * 6;
            }
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

            if (total * 2 > 50)
            {
                return 0;
            }
            else 
            {
                return total * 2;
            }
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
                if (password.Length > 200)
                {
                    return 200;
                }
                else
                {
                    return password.Length;
                }
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
                if (password.Length > 200)
                {
                    return 200;
                }
                else
                {
                    return password.Length;
                }
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

            if (itemCount * 2 > 50)
            {
                return 50;
            }
            else
            {
                return itemCount * 2;
            }
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

            if (dupes * 2 > 50)
            {
                return 50;
            }
            else
            {
                return dupes * 2;
            }
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

            if (dupes * 2 > 50)
            {
                return 50;
            }
            else
            {
                return dupes * 2;
            }
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

            if (dupes * 2 > 50)
            {
                return 50;
            }
            else
            {
                return dupes * 2;
            }
        }

        public int SequentialLetters(string password)
        {
            int dupes = 0;
            if (password.Length < 2)
            {
                return 0;
            }
            else
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(password);

                for (int i = 0; i < password.Length - 1; i++)
                {
                    var tmp1 = asciiBytes[i];
                    var tmp2 = asciiBytes[i+1];

                    if (tmp1+1 == (tmp2))
                    {
                        dupes += 1;
                    }
                }

                if (dupes * 3 > 50)
                {
                    return 50;
                }
                else
                {
                    return dupes * 3;
                }
            }

            /*
            //work out ascii value of each letter and increment it to check the next
            for (int i = 0; i < password.Length - 1; i++)
            {
                if ((Char.IsDigit(password[i + 1])) && (Char.IsDigit(password[i]) == true))
                {
                    dupes += 1;
                }
            }
            return dupes * 2;*/
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

