using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Enums are user defined data types(UDTs) that are used to define Named Constants.
 * If U have a set of related constants, you can use an enum to to define them in single type
 */
namespace SampleConApp
{
    enum Days : long //Default is int, U can make it long, byte, short etc.
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }
    internal class Ex04Enums
    {
        static void Main(string[] args)
        {
            Days d1 = Days.Wednesday;
            Console.WriteLine($"The selected date is {d1} and its integral value is {(int)d1}. Its internal data type is {d1.GetTypeCode()}");

            Console.WriteLine("Enter the day from the list below u want to start work");
            Array values = Enum.GetValues(typeof(Days)); // Inbuilt property , typeof() gives the data type . Gets the values of the enum. The Enum reference is obtained using typeof operator.
            foreach (var value in values ) // Can use Days instead of var
            {
                Console.WriteLine(value);
            }

            string dayInput = Console.ReadLine();
            Days day = Enum.Parse<Days>(dayInput); // true for case-insensitive variables
            Console.WriteLine("The selected day is " + day);
        }
    }
}
