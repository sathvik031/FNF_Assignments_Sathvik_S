using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment2
    {
        public static void DisplayOddEven(int[] numbers)
        {
            ArrayList odd = new ArrayList();
            ArrayList even = new ArrayList();

            for (int i=0; i<numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    odd.Add(numbers[i]);
                }
                else
                {
                    even.Add(numbers[i]);
                }
            }
            Console.Write("Odd numbers -> ");
            foreach(int item in odd)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.Write("Even numbers -> ");
            foreach (int item in even)
            {
                Console.Write(item + " ");
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            DisplayOddEven(numbers);
        }
    }
}
