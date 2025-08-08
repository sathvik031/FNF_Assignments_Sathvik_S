using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;// This is the namespace for Generics.

//Generics is a feature of .NET that can allow to create classes, methods and interfaces that can work on any kind of data type. They are similar to templates in C++., they are said to be type-safe 


namespace SampleConApp.GenericsEx
{
    class Employee : object
    {
        //data, shall be private by default
        private int _id;
        string _name;
        string _address;
        double _salary;
        string _designation;

        public int EmpID
        {
            get { return _id; }
            set { _id = value; }//value is the smart keyword that refers to the value being assigned to the property
        }

        public string EmpName
        {
            get { return _name; }
            set { _name = value; }
        }


        public string EmpAddress
        {
            get { return _address; }
            set { _address = value; }
        }


        public double EmpSalary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        //Tell what makes UR object unique. This is called as ToString() method. It is a virtual method that can be overridden.
        public override string ToString()
        {
            return EmpID.ToString();
        }

        //GetHashCode() is used to get a hash code for the object. It is used in collections like HashSet, Dictionary etc. The hash value is used to quickly locate the object in the collection.
        public override int GetHashCode()
        {
            return EmpID;
        }
        //Implement the logical Equivalence for the Employee class.
        public override bool Equals(object? obj)
        {
            //If 2 EmpIds are same, then the objects are considered equal.
            if (obj is Employee emp)
            {
                if (this.EmpID == emp.EmpID)
                    return true;
                else
                    return false;
            }
            return false; //If the object is not of type Employee, then return false.
        }
    }

//Generics is a feature of .NET that can allow to create classes, methods and interfaces that can work on any kind of data type. They are similar to templates in C++.
//They are said to be type-safe, meaning that they can enforce type constraints at compile time, reducing runtime errors. U dont have to unbox the data when U use generics, as they are already type-safe.

        internal class Ex19GenericsDemo
        {
            static void Main(string[] args)
            {
                //listExample();
                //HashSetExample();
                DictionaryExample();
            }

        //Similar to hashtable, but it is type-safe and does not allow null keys. It is a collection of Key-Value pairs. Each item in the dictionary is an object of KeyValuePair<TKey, TValue> class where TKey and TValue represents the data types that u want to use for the Key and Value respectively
        private static void DictionaryExample()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("John", "apple123");
            users.Add("Bob", "mango123");
            users.Add("Joe", "test123");
            users.Add("Micheal", "code123");
            users.Add("Jenny", "pass123"); //This is another way. but, if the key already exists, it will update the value.

            var choice = ConsoleUtil.GetInputString("Enter your choice signup or signin: ");
            var user = ConsoleUtil.GetInputString("Enter the username: ");
            var password = ConsoleUtil.GetInputString("Enter the password: ");
            if(choice == "signup")
            {
                if (users.ContainsKey(user))
                {
                    Console.WriteLine("The user already exists. Try signing in.");
                }
                else 
                {
                    users.Add(user, password);
                }
            }
            else if(choice == "signin")
            {
                if (users.ContainsKey(user) && users[user] == password)
                {
                    Console.WriteLine("Welcome");
                }
                else
                {
                    Console.WriteLine("Invalid username / password");
                }
            }
        }

        //HashSet is a collection of unique items. It is similar to a List. No Duplicates are allowed.
        private static void HashSetExample()
            {
                //HashSetSimpleMethod();
                HashSetOnEmployeeExample();
            }
            // Modify the code in the Employee class to override GetHashCode() and Equals() method
            private static void HashSetOnEmployeeExample()
            {
                //In HashSet, the items are compared using the GetHashCode() and Equals() methods. If two items have the same hash code, then they are compared with the Equals method and then are considered equal/unequal.
                HashSet<Employee> employees = new HashSet<Employee>();
                employees.Add(new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" });
                employees.Add(new Employee { EmpID = 2, EmpName = "Jane", EmpAddress = "Los Angeles", EmpSalary = 60000, Designation = "Developer" });
                employees.Add(new Employee { EmpID = 3, EmpName = "Doe", EmpAddress = "Chicago", EmpSalary = 55000, Designation = "Tester" });
                employees.Add(new Employee { EmpID = 4, EmpName = "Alice", EmpAddress = "Houston", EmpSalary = 70000, Designation = "Designer" });
                employees.Add(new Employee { EmpID = 5, EmpName = "Bob", EmpAddress = "Phoenix", EmpSalary = 65000, Designation = "Analyst" });
                employees.Add(new Employee { EmpID = 1, EmpName = "Jonny", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" });
                employees.Add(new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" });

                foreach (Employee emp in employees)
                {
                    Console.WriteLine($"{emp.EmpName} earns a salary of {emp.EmpSalary:C}");
                }
            }

            private static void HashSetSimpleMethod()
            {
                HashSet<string> names = new HashSet<string>();
                names.Add("John");
                names.Add("Jane");
                names.Add("Doe");
                if (!names.Add("John"))
                    Console.WriteLine("John is already the member of the  Team");
                Console.WriteLine("The total members of the team: " + names.Count);
            }

            private static void listExample()
            {
                List<string> names = new List<string>();
                names.Add("John");//Add only strings to the list.
                names.Add("Jane");
                names.Add("Doe");
                names.Add("Smith");
                names.Add("Alice");
                names.Add("Bob");
                names.Insert(2, "Charlie");//Insert at index 2. This will shift the other items to the right.

                //Iterating through the list using foreach loop. foreach is a easy way to iterate through a collection in C#. It is forward-only and readonly. U can move by 1 number at a time.
                foreach (string name in names)
                {
                    Console.WriteLine(name.ToUpper());//No unboxing is required as the list is of type string.
                }
                //Like ArrayList, here also U can insert, remove, and search for items in the list from any where.
                string nameToFind = ConsoleUtil.GetInputString("Enter a name to find: ");
                if (!names.Contains(nameToFind))
                {
                    Console.WriteLine("UR Entered Name does not exist");
                }
                else
                {
                    //for(int i =0; i < names.Count; i++)
                    //{
                    //    if(names[i] == nameToFind)
                    //    {
                    //        Console.WriteLine($"UR Entered Name is found at index {i}");
                    //        break; //Exit the loop once the name is found.
                    //    }
                    //}
                    var index = names.IndexOf(nameToFind); //This will return the index of the name if found, otherwise -1.
                    Console.WriteLine($"UR Entered Name is found at index {index}");
                }
            }
        }
    }
