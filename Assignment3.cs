using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    static class ConsoleUtil
    {
        public static string GetInputString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetInputInt(string question)
        {
            return int.Parse(GetInputString(question));
        }

        public static double GetInputDouble(string question) => double.Parse(GetInputString(question));
    }
    internal class Assignment3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calculator program.");
            bool processing = true;
            do
            {
                double first = ConsoleUtil.GetInputDouble("Enter the 1st number: ");
                double second = ConsoleUtil.GetInputDouble("Enter the 2nd number: ");

                string choiceStr = ConsoleUtil.GetInputString("Enter the operator");
                char choice = choiceStr[0];

                double result = MathCalc(first, second, choice);
                Console.WriteLine("The result is: " + result);
                string ch = ConsoleUtil.GetInputString("Enter Y to continue and N to exit");
                processing = ch.ToUpper() == "Y" ? true : false;
            } while (processing);
        }

        private static double MathCalc(double first, double second, char choice)
        {
            
            switch(choice)
            {
                case '+': return first + second;
                case '-': return first - second;
                case '*': return first * second;
                case '/': return first / second;
                default:
                    Console.WriteLine("Invalid Choice");
                    return 0;
            }
            
        }
    }
}
