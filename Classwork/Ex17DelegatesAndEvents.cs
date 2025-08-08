using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Similar to function pointers of C++
 * A Delegate is a signature of a method that can be used to call inside another function.
 * Delegate is more like a function type.
 * Delegates are type-safe and secure, meaning they can only call methods that match their signature.
 * There are a list of Builtin delegates provided by .NET for regular usages: Action(void), Func(Non-void) are generic delegates that can be used on multiple datatypes and multiple number of parameters(16 parameters), Threadstart used for multi threading, Predicate which is used in Collections.
 */
namespace SampleConApp
{
    //User created delegate
    delegate double MathOp(double x, double y);
    internal class Ex17DelegatesAndEvents
    {
        //BuiltIn delegate
        //Func<T> is a generic delegate used to perform ops on diff. types & parameters.
        static void InvokeFunc(Func<double, double, double> func) // starting parameters -> actual and last parameter is the return type 
        {
            Console.WriteLine("Enter the first num: ");
            double v1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second num: ");
            double v2 = double.Parse(Console.ReadLine());
            double result = func(v1, v2);
            Console.WriteLine("The result: " + result);
        }
        static void InvokeMethod(MathOp func)
        {
            Console.WriteLine("Enter the first num: ");
            double d1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second num: ");
            double d2 = double.Parse(Console.ReadLine());
            double result = func(d1, d2);
            Console.WriteLine("The result: " + result);
        }
        static void Main(string[] args)
        {
            //Old syntax for using delegate obj
            MathOp obj = new MathOp(add);
            InvokeMethod(obj);

            //New syntax
            InvokeMethod(add);
            
            //Using Built in delegates
            InvokeFunc(mul);
        }

        static double add(double a, double b) =>  a+b;
        static double mul(double a,double  b) => a * b;
    }
}
