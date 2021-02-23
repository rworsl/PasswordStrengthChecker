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
            int total2 = 0;
            //string password = "apsoa5@abc";
            //string password = "iloveyoumybubbaloo!";
            //string password = "DispersalCharger@EnticingOverripe";
            //string password = "P4ternityPr3natalV3nding6racious";
            string password = "0!l7hr@$h(0nfu$ingFl4m@bl£";

            var Program = new Program();

            total += Program.NumberOfCharacters(password);
            //max 200
            Console.WriteLine("NumberOfCharacters: " + total);

            //max 400
            total += Program.CountUppercaseLetters(password);
            Console.WriteLine("CountUppercaseLetters: " + total);
            
            //max 100
            total += Program.CountLowercaseLetters(password);
            Console.WriteLine("CountLowercaseLetters: " + total);

            //max 50
            total += Program.CountNumbers(password);
            Console.WriteLine("CountNumbers: " + total);

            //max 50
            total += Program.CountSymbols(password);
            Console.WriteLine("CountSymbols: " + total);

            //max 50
            total += Program.CountMiddleSymbols(password);
            Console.WriteLine("CountMiddleSymbols: " + total);

            //max 10
            total += Program.MeetsAllRequirements(password);
            Console.WriteLine("MeetsAllRequirements: " + total);
            Console.WriteLine("");

            //Max possible = 860

            //max 200
            total2 += Program.onlyLetters(password);
            Console.WriteLine("onlyLetters: " + total2);

            //max 200
            total2 += Program.onlyNumbers(password);
            Console.WriteLine("onlyNumbers: " + total2);

            //max 50
            total2 += Program.checkRepeatCharacters(password);
            Console.WriteLine("checkRepeatCharacters: " + total2);

            //max 50
            total2 += Program.ConsecutiveUpperLetters(password);
            Console.WriteLine("ConsecutiveUpperLetters: " + total2);

            //max 50
            total2 += Program.ConsecutiveLowerLetters(password);
            Console.WriteLine("ConsecutiveLowerLetters: " + total2);

            //max 50
            total2 += Program.ConsecutiveNumbers(password);
            Console.WriteLine("ConsecutiveNumbers: " + total2);

            //max 50
            total2 += Program.SequentialLetters(password);
            Console.WriteLine("SequentialLetters: " + total2);

            var finalTotal = Program.scaledScore(total);
            Console.WriteLine("Scaled :" + finalTotal);
            
            
            Console.WriteLine("");
            Console.WriteLine("Final total: " + (total - total2));
        }

        public double scaledScore(int total)
        {
            /*var oldRange = 250;
            var newRange = 100;
            var combined = (double)newRange / oldRange;

            var Value = (double)(total * combined);

            Console.WriteLine(Value);*/
            var Value = total / 2.5;
            if (Value > 100)
            {
                return 100;
            }
            else
            {
                return Value;
            }
            return Value;
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

            if (total <= 3)
            {
                return 0;
            }
            else
            {
                return total * 2;
            }
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
            /*
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
            */

            HashSet<char> characters = new HashSet<char>();
            foreach(char i in password)
            {
                characters.Add(i);
            }

            int originalTotal = password.Length;
            int newTotal = characters.Count;

            int Result = originalTotal - newTotal;

            return Result > 50 ? 50 : Result;
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

