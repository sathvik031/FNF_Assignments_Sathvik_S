using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignments
{
    internal class Assignment6
    {
        static Hashtable monthDays = new Hashtable();
        
        static bool isLeap(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
        static bool isValidDate(int year, int month, int day)
        {
            
            if (year <= 0 || year > 3000)
            {
                return false;
            }
            if (isLeap(year))
            {
                monthDays[2] = 29;
            }
            if (month <= 0 || month > 12)
            {
                return false;
            }
            if(day <= 0 || day > (int)monthDays[month])
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            setTable();
            do
            {
                int year = ConsoleUtil.GetInputInt("Enter the year: ");
                int month = ConsoleUtil.GetInputInt("Enter the month: ");
                int day = ConsoleUtil.GetInputInt("Enter the day: ");

                bool isValid = isValidDate(year, month, day);
                if (isValid)
                {
                    Console.WriteLine("Valid date!");
                }
                else
                {
                    Console.WriteLine("Invalid date, please try again.");
                }
            } while (true);
        }
        public static void setTable()
        {
            monthDays.Add(1, 31);
            monthDays.Add(2, 28);
            monthDays.Add(3, 31);
            monthDays.Add(4, 30);
            monthDays.Add(5, 31);
            monthDays.Add(6, 30);
            monthDays.Add(7, 31);
            monthDays.Add(8, 31);
            monthDays.Add(9, 30);
            monthDays.Add(10, 31);
            monthDays.Add(11, 30);
            monthDays.Add(12, 31);
        }
    }
}
