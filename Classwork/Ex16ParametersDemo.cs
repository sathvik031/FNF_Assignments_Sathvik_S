using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Functions or methods allow to have parameters in them.
//C# supports diff types of parameters -> ref, out, params and normal
//Out parameter -> value is assigned inside the func , ref -> may or may not give an output result
namespace SampleConApp
{
    internal class Ex16ParametersDemo
    {
        //Lambda methods are methods with a single expression that can be used to create delegates or expression tree types. They are often used for short, inline methods.
        //public static void NormalParameter(int x) => Console.WriteLine($"Normal Paramenter: {x}");
        public static void NormalParameter(int x)
        {
            Console.WriteLine($"Normal Paramenter: {x}");
            x = 123;
            Console.WriteLine("Value of inside NormalParameter Func: " + x);
        }
        //Out Parameter
        //When using out parameters, the method must assign a value to the out parameter before returning. The out parameter does not need to be initialised befoe being passed to the method
        public static void AddFunc(int first, int second, out double result) => result = first + second;

        public static void ArithmeticFunction(int first, int second, ref double addedValue, ref double subtractedValue, ref double multipliedValue, ref double dividedValue)
        {
            addedValue = first + second;
            subtractedValue = first - second;
            multipliedValue = first * second;
            if(second != 0)
            {
                dividedValue = first / second;
            } else
            {
                Console.WriteLine("Division by zero is not allowed");
            }
        }
        //params example
        public static long AddNumbers (params int[] numbers)
        {
            long sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        static void Main(string[] args)
        {
            //NORMAL PARAMETERS
            int x = 10;
            NormalParameter(x);
            Console.WriteLine("Value of x after NormalParameter func is executed: " + x);

            //OUT PARAMETERS
            double result;
            AddFunc(10, 20, out result); //retains the result in the out parameter.even after the method call, the out parameter retains the value assigned in the method
            Console.WriteLine("The result: " + result);

            //REF PARAMETERS
            double addedValue = 0, subtractedValue = 0, multipliedValue = 0, dividedValue = 0;
            ArithmeticFunction(30, 10, ref addedValue, ref subtractedValue, ref multipliedValue, ref dividedValue);
            Console.WriteLine($" Added value: {addedValue} \n Subtracted value: {subtractedValue} \n Multiplication value: {multipliedValue} \n Division value: {dividedValue} \n");

            //PARAMS 
            long sum = AddNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine($"Sum of params function: {sum}");
        }
    }
}
