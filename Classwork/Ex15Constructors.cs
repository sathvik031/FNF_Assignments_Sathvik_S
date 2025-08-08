using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.ConstructorsExample
{
    class SuperClass
    {
        public SuperClass() {
            Console.WriteLine("Super class constructor is called");
        }
        public SuperClass(string value) : this()
        {
            Console.WriteLine($"Super class constructor with {value} as parameter");
        }
    }

    class BaseClass : SuperClass
    {
        public BaseClass(string msg) : base(msg)
        {
            Console.WriteLine("Base class constructor is called");
        }
    }

    class DerivedClass : BaseClass
    {
        public DerivedClass(string msg) : base(msg)
        {
            Console.WriteLine("Derived class constructor is called");
        }
    }
    internal class Ex15Constructors
    {
            static void Main(string[] args)
            {
                //SuperClass superClass = new SuperClass();
                //BaseClass baseClass = new BaseClass();
                DerivedClass derivedClass = new DerivedClass("Virat");
            }
        }
}
