using System;
using System.Collections.Generic;
using System.Text;

namespace BornToMove
{
    static class ConsoleInput
    {
        public static int? AskNumber(int min, int max, string question)
        {
            Console.WriteLine(question);

            int? number = null;

            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (number >= min && number <= max)
                {
                    return number;
                }

                Console.WriteLine("Input not valid, it must be a number between " + min + " and " + max + ". Please try again:");
            }
        }

        public static bool AskYesNo(string question)
        {
            Console.WriteLine(question);

            while (true)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                    case "y":
                        return true;
                        break;

                    case "no":
                    case "n":
                        return false;
                        break;
                }

                Console.WriteLine("Input not valid, the answere can be \"yes\", \"y\", \"no\" and \"n\". Please try again:");
            }
        }
    }
}
