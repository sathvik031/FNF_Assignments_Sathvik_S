using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex07TuplesExample
    {
        static void Main(string[] args)
        {
            var myExample = (45, "MyName");
            Console.WriteLine($"First item: {myExample.Item1} \n Second item: {myExample.Item2}");
            Console.WriteLine("The data type is : " + myExample.GetType().Name);

            //U can have named tuples
            var person = (Name: "Sathvik", Age: 24, City: "New York");
            Console.WriteLine($"Name: {person.Name} from {person.City} and is aged {person.Age}");

            var (longit, latit) = GetCoordinates();
            Console.WriteLine($"The coordinates are ({longit}, {latit})");

            var (name, number) = GetMobNo();
            Console.WriteLine($"The Person details is ({name}, {number})");

        }

        /// <summary>
        /// Implements a method that returns a tuple with two double values representing coordinates.
        /// </summary>
        /// <returns>Tuple of type (double, double)</returns>
        static (double, double) GetCoordinates()
        {
            return (123.4535, 9843278.4329);
        }
        static (string, double) GetMobNo()
        {
            return ("Virat", 7632174673);
        }
    }
}
