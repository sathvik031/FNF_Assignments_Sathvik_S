using System; 

namespace SampleConApp
{
    /*
     * All data types in C# are based on Common Type System(CTS) of .NET FrameWork.
     * CTS provides a commonn set of data types for all languages of .NET.
     * Primitive types or known types are data types that are common among all languages: They are 
     * also called VALUE TYPES.
     * Integeral Types: byte(2 Bit), short(16), int(32), long(64)
     * Floating Types: float(SIngle), double(Double), decimal(128Bit)
     * Other types: Char(2 Bytes), Bool(1 Byte). Tuples.
     */
    class Ex02DataTypes
    {
        static void Main(string[] args)
        {
            int iVal = 123;
            long lVal = 234324343;
            float fVal = 234.45f;
            double dValue = 23434.2344;
            char strText = 'a'; //Use single quotes.
            bool bValue = true;

            //Console.WriteLine($"The Value of iVal is {iVal}");
            Console.WriteLine("The Value of iVal is {0} \n The value of lVal is {1} \n The value of fVal is {2} " +
                "The value of dValue is {3} \n The value of strText is {4} \n the value of bValue is {5}"
                , iVal, lVal, fVal, dValue, strText, bValue);

            DisplayUserDetails();

        }

        static void DisplayUserDetails()
        {
            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the age");
            //get the string and later convert it to int.
            int iAge = int.Parse(Console.ReadLine()); //Parse method is found in every Value type.
            //The function converts the string to its Type.

            Console.WriteLine("Enter your mobile number");
            long lMobile = long.Parse(Console.ReadLine());

            Console.WriteLine($"Name is {name} \n Age is {iAge} \n Number is {lMobile}");

        }

        static void TypeCastingExample()
        {
            //Convert from int to long.
            int iVal = 123;
            long lVal = iVal; //Implicit conversion from int it long.
            double dVal = 123.45; // Implicit conv. from int to double.
            lVal = (long)dVal; //Explicit conversion from double to long.

            //U can use convert class to convert from one type to another. This is more safe than casting. If the casting is not possible, it throws ans exception and doesnt give garbage value.
            lVal = Convert.ToInt64(dVal); //Convert class is available in System namespace. It has methods to convert from one type to another.
        }
    }
}