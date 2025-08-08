using SampleConApp.CustomCollections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex21FileIOExample
    {
        static void Main(string[] args)
        {
            //DisplayFilesDirectories();
            //CreateDirectory();
            //CreatingCSVFile();
            List<Customer> customers = ReadingCSVFile();
            foreach(Customer customer in customers)
            {
                Console.WriteLine(customer.CustomerName);
            }

        }
        public static void DisplayFilesDirectories()
        {
            Console.WriteLine("-----------Displaying files -----------");
            var files = Directory.GetFiles("C:\\Dummy");
            foreach (var file in files)
            {
                var selected_file = new FileInfo(file);
                Console.WriteLine($"The name: {selected_file.Name}, created on {selected_file.CreationTime}");

            }

            Console.WriteLine("-----------Displaying directories and its info -----------");
            var directorys = Directory.GetDirectories("C:\\Temp");
            foreach (var dirPath in directorys)
            {
                var dir = new DirectoryInfo(dirPath);
                Console.WriteLine(dir.Name);
            }
        }

        public static void CreateDirectory()
        {
            var directorys = Directory.GetDirectories("C:\\Temp");
            var newDir = "C:\\TestDir";
            var dirInfo = Directory.CreateDirectory(newDir);
            var parent = dirInfo.Parent;
            foreach (var dir_path in directorys)
            {
                var info = new DirectoryInfo(dir_path);
                foreach (var file in info.GetFiles())
                {
                    Console.WriteLine(file.Name);
                }
            }
        }

        private static void CreatingCSVFile()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerName = "John Doe",
                BillAmount = 101.1
            };
            var filePath = "C:\\Users\\6152798\\Desktop\\customer.csv";
            var content = $"{customer.CustomerId},{customer.CustomerName},{customer.BillAmount}";
            File.WriteAllText(filePath, content);
        }

        private static List<Customer> ReadingCSVFile()
        {
            var filePath = "C:\\Users\\6152798\\Desktop\\customer.csv";
            var lines = File.ReadAllLines(filePath);
            List<Customer> list = new List<Customer>();
            foreach(var line in lines) 
            {
                var words = line.Split(",");
                var cust = new Customer
                {
                    CustomerId = Convert.ToInt32(words[0]),
                    CustomerName = words[1],
                    BillAmount = Convert.ToDouble(words[2])
                };
                list.Add(cust);
            }
            return list;
        } 
    }
}
