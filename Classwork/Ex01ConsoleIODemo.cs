using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Console is a .net class that represents the console IO of the OS.
 * It has static methods and properties that can be called to perform IO operations on the Console.
 * User inputs are captured using -> ReadLine and it returns string.
 * User outputs are displayed in the Console using WriteLine.
 * Main class can be selected from the properties dialog.
 * U can have multiple Mains in the project but we should set the entry point class at the compile time
 */
namespace SampleConApp
{
    internal class Ex01ConsoleIODemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the address");
            string address = Console.ReadLine();

            Console.WriteLine($"The inputs are as follows: \n the Name entered is {name} \n the Address is {address}");

        }
    }
}
