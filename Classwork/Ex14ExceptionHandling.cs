using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Exceptions are scenarios that occur during the execution of a program that disrupt
 */
namespace SampleConApp
{

    [Serializable]
    public class DbFailureException : Exception
    {
        public DbFailureException() { }
        public DbFailureException(string message) : base(message) { }
        public DbFailureException(string message, Exception inner) : base(message, inner) { }
    }
    internal class Ex14ExceptionHandling
    {
        static void Main(string[] args)
        {
            //firstExample();
            //secondExample();
            try
            {
                thirdExample();
            }
            catch(DbFailureException ex)
            {
                Console.WriteLine($"Custom exception caught: {ex.Message}");
                //handle the exeception or log it
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General exception caught: {ex.Message}");
                //handle the exeception or log it
            }
            finally
            {
                Console.WriteLine("Execution completed. Thank you for trying our example.");
            }
        }
        /// <summary>
        /// Validates user input for username and password.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Wrong entry for username and password</exception>

        static void thirdExample()
        {
            bool isConnected = true;
            isConnected = false;
            if (isConnected)
            {
                Console.WriteLine("The DB is connected");

            }
            if (!isConnected)
            {
                throw new DbFailureException("The db connection failed");
            }
        }
        static void secondExample()
        {
            try
            {
                ThrowingExceptionExample();
            }
            catch (UnauthorizedAccessException)
            {

                Console.WriteLine("Incorrect username or password");

            }
        }
        private static void ThrowingExceptionExample()
        {
            string uname = ConsoleUtil.GetInputString("Enter the username");
            string pwd = ConsoleUtil.GetInputString("Enter the password");
            if(uname == "admin" && pwd == "admin")
            {
                Console.WriteLine("Welcome to the system");
            } 
            else
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }
        }
        static void firstExample()
        {
        RETRY:
            try
            {
                Console.WriteLine("Enter the age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine($"the age is {age}");
                Console.WriteLine("Enter a number: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the divisor");
                int div = int.Parse(Console.ReadLine());
                int quotient = num / div;
                Console.WriteLine($"The quotient is {quotient}");
            }
            catch (FormatException exc)
            {
                Console.WriteLine($"The System generated the message {exc}");
                Console.WriteLine(exc.Message);
                Console.WriteLine("Input should be a valid no");
                goto RETRY;
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine($"The System generated the message {exc}");
                Console.WriteLine("Input should have a parameter");
                goto RETRY;
            }
            catch (OverflowException exc)
            {
                Console.WriteLine($"The System generated the message {exc}");
                Console.WriteLine($"The input should be between {int.MinValue} and {int.MaxValue}");
                goto RETRY;
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine($"The System generated the message {exc}");
                Console.WriteLine("Division by zero is not allowed");
                goto RETRY;
            }
            finally
            {
                Console.WriteLine("Finally block executed. This will always run.");
                Console.WriteLine("Thanks for trying our example");
            }
        }
    }
}
