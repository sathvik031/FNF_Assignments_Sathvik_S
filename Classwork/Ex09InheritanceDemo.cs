namespace SampleConApp
{
    class BaseClass //This class is iternal. Internal classes are accessible only within the assembly/project
    {
        public void Display()
        {
            Console.WriteLine("Base Class Display Method");
        }
    }

    //A derived class that inherits from BaseClass is required if u want to add new functionality or override existing functionality of the base class. A class is immutable by default, meaning you cannot change change its functionality unless you inherit from it. (Open-Closed Principle of SOLID)
    //C# does not support multiple inheritance, meaning a class cannot inherit from more than one base class at the same level. However, it can implement multiuple interfaces, C# supports multi level inheritance meaning
    class DerivedClass : BaseClass
    {
        public void Show()
        {
            Console.WriteLine("Show method is implemented");
        }
    }

    internal class InheritanceExample
    {
        static void Main(string[] args)
        {
            DerivedClass derived = new DerivedClass();
            derived.Show();
            derived.Display();
        }
    }


}