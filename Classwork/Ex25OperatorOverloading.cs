using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmpSalary { get; set; }

        public static Employee operator +(Employee lhs, int rhs)
        {
            lhs.EmpSalary += rhs;
            return lhs;
        }

        public static Employee operator -(Employee lhs, int rhs)
        {
            lhs.EmpSalary -= rhs;
            return lhs;
        }
    }
}
namespace SampleConApp
{
    using OperatorOverloading;
    internal class Ex25OperatorOverloading
    {
        static void Main(string[] args)
        {
            OperatorOverloading.Employee emp = new OperatorOverloading.Employee();
            emp = emp + 100000;
            emp -= 100;
            Console.WriteLine($"The employee salary is {emp.EmpSalary}");
        }
    }
}
