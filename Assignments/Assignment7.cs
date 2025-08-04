using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignments
{
    internal class Assignment7
    {
        static bool isPrimeNumber(int num)
        {
            if(num == 0 || num == 1) return false;
            for(int i=2; i<Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                int num = ConsoleUtil.GetInputInt("Enter the number to check for prime number");
                if (isPrimeNumber(num))
                {
                    Console.WriteLine($"The given number {num} is prime");
                }
                else
                {
                    Console.WriteLine($"The given number {num} is not prime");
                }
                string choice = ConsoleUtil.GetInputString("Enter Y to continue and N to exit").ToUpper();
                processing = choice == "Y" ? true : false; 
            } while (processing);
        }
    }
}
