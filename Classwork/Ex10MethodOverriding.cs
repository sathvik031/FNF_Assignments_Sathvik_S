namespace SampleConApp
{
    enum PaymentType
    {
        Cash,
        Card,
        Cheque,
        UPI
    }
    class ParentClass
    {
        public void Display()
        {
            Console.WriteLine("Welcome to payment gateway");
        }

        public virtual void MakePayment(double amount, PaymentType paymentType)
        {
            if (paymentType == PaymentType.Cash)
            {
                Console.WriteLine($"Payment of {amount} made in cash.");
            } else if (paymentType == PaymentType.Cheque)
            {
                Console.WriteLine($"Payment of {amount} made in cheque.");
            } else
            {
                Console.WriteLine("Invalid mode of Payment. Payment not accepted");
            }
        }

    }

    //base keyword is used to refer the immediate base class from the current class.
    class SonClass : ParentClass
    {
        public void show()
        {
            Console.WriteLine("This is child class");
        }
        public override void MakePayment(double amount, PaymentType paymentType)
        {
            if (paymentType == PaymentType.Cash)
            {
                Console.WriteLine($"Payment of {amount} made in cash.");
            }
            else if (paymentType == PaymentType.UPI)
            {
                Console.WriteLine($"Payment of {amount} made in UPI.");
            }
            else
            {
                Console.WriteLine("Invalid mode of Payment. Payment not accepted");
            }
        }
    }
    internal class Ex10MethodOverriding
    {
        static ParentClass CreateObject()
        {
            Console.WriteLine("Enter the type of the object U want to create, Press P for Parent and S for Son");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "P")
            {
                return new ParentClass(); //Returning ParentClass object
            }
            else if (choice.ToUpper() == "S")
            {
                return new SonClass(); //Returning SonClass object
            }
            else
            {
                Console.WriteLine("Invalid choice, No object is created");
                return null;
            }
        }
        static void Main(string[] args)
        {
            ParentClass parent = CreateObject(); //Upcasting: Treating ParentClass as ParentClass
            if (parent == null)
            {
                Console.WriteLine("No object created, Exiting the program.");
                return;
            }
            parent.Display();
            parent.MakePayment(1000, PaymentType.Cash);
            parent.MakePayment(2000, PaymentType.Cheque);

            //Downcasting: 
            //DateOnly methods that are defined in ParentClass can be called on parent object. If u want to call methods that are defined in the SonClass, U need to downcast the parent object to SonClass using the 'as' keyword or by directly casting.
            if(parent is SonClass)
            {
                SonClass son = parent as SonClass; //Downcasting: treating ParentClass as SonClass
                //SonClass son = (SonClass)parent;
                son.show(); //Calling method from SonClass
            }
            //parent = new SonClass(); //Upcasting: Treating SonClass as ParentClass
            parent.MakePayment(2000, PaymentType.Cheque);

        }
    }
}