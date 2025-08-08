using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    interface IExample
    {
        void ShowExample();
    }
    interface IExample2
    {
        void ShowExample();
    }
    interface ISimple
    {
        void ShowSimple();
    }
    class SimpleExample : IExample, ISimple //Multiple interface implementation
    {
        public void ShowExample() 
        {
            Console.WriteLine("This is an example of implementing multiple interfaces.");
        }
        public void ShowSimple()
        {
            Console.WriteLine("This is an example of implementing multiple interfaces at same level.");
        }
    }

    class ExampleSquare: IExample, IExample2 //Multiple interface implementation
    {
        public void ShowExample()
        {
            Console.WriteLine("This is an std implementation of ShowExample Method");
        }
        //We shall implement the interface methods Explicitly to avoid ambiguity.
        void IExample.ShowExample()
        {
            Console.WriteLine("This is an explicit implementation of ShowExample Method for IExample");
        }
        void IExample2.ShowExample()
        {
            Console.WriteLine("This is an explicit implementation of ShowExample Method for IExample2");
        }
    }
    internal class Ex13AdvancedInterfaceConcepts
    {
        static void Main(string[] args)
        {
            //IExample ex = new SimpleExample();
            //ex.ShowExample();
            //ISimple sim = new SimpleExample();
            //sim.ShowSimple();

            ExampleSquare exClass = new ExampleSquare();
            exClass.ShowExample();
            IExample ex = new ExampleSquare();
            ex.ShowExample();
            IExample2 ex1 = (IExample2)ex;
            ex1.ShowExample();
        }
    }
}
