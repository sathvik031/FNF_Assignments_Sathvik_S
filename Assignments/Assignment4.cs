using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment4
    {
        static void Main(string[] args)
        {
            string dataType = ConsoleUtil.GetInputString("Enter the type of the array(int, double, string, char): ").ToLower();
            int size = ConsoleUtil.GetInputInt("Enter the size of the array: ");
            Object arr = createArray(dataType, size);
            Console.WriteLine($"Enter {size} elements for array of type {dataType}");
            if(arr is int[] intArr)
            {
                for(int i=0; i<intArr.Length; i++)
                {
                    intArr[i] = int.Parse(Console.ReadLine());
                }
                printArr(intArr);
            } 
            else if (arr is double[] doubleArr)
            {
                for (int i = 0; i < doubleArr.Length; i++)
                {
                    doubleArr[i] = double.Parse(Console.ReadLine());
                }
                printArr(doubleArr);
            }
            else if (arr is char[] charArr)
            {
                for (int i = 0; i < charArr.Length; i++)
                {
                    charArr[i] = char.Parse(Console.ReadLine());
                }
                printArr(charArr);
            }
            else if (arr is string[] stringArr)
            {
                for (int i = 0; i < stringArr.Length; i++)
                {
                    stringArr[i] = Console.ReadLine();
                }
                printArr(stringArr);
            }
        }

        public static void printArr<T>(T[] arr)
        {
            foreach(var item in arr)
            {
                Console.Write(item+ " ");
            }
            Console.WriteLine();
        }

        private static object createArray(string dataType, int size)
        {
            if(dataType == "int")
            {
                int[] arr = new int[size];
                return arr;
            }
            else if (dataType == "double")
            {
                double[] arr = new double[size];
                return arr;
            }
            else if (dataType == "char")
            {
                char[] arr = new char[size];
                return arr;
            }
            else if (dataType == "string")
            {
                string[] arr = new string[size];
                return arr;
            }
            return null;
        }
    }
}
