using DotnetCoreAssignment.DATA;
using System;
using System.Linq;

namespace DotnetCoreAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Get All Students");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertStudent();
                        break;
                    case "2":
                        UpdateStudent();
                        break;
                    case "3":
                        GetAllStudents();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void InsertStudent()
        {
            using var dbContext = new StudentContext();

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());

            var newStudent = new Student
            {
                StudentName = name,
                Course = course,
                Marks = marks
            };

            dbContext.Students.Add(newStudent);
            dbContext.SaveChanges();
            Console.WriteLine("Student inserted successfully.");
        }

        static void UpdateStudent()
        {
            using var dbContext = new StudentContext();

            Console.Write("Enter Student ID to Update: ");
            int studentId = int.Parse(Console.ReadLine());

            var student = dbContext.Students.Find(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter New Student Name: ");
            student.StudentName = Console.ReadLine();

            Console.Write("Enter New Course: ");
            student.Course = Console.ReadLine();

            Console.Write("Enter New Marks: ");
            student.Marks = int.Parse(Console.ReadLine());

            dbContext.SaveChanges();
            Console.WriteLine("Student updated successfully.");
        }

        static void GetAllStudents()
        {
            using var dbContext = new StudentContext();

            var students = dbContext.Students.ToList();
            Console.WriteLine("\n--- Student List ---");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}, Name: {student.StudentName}, Course: {student.Course}, Marks: {student.Marks}");
            }
        }

        static void DeleteStudent()
        {
            using var dbContext = new StudentContext();

            Console.Write("Enter Student ID to Delete: ");
            int studentId = int.Parse(Console.ReadLine());

            var student = dbContext.Students.Find(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            Console.WriteLine("Student deleted successfully.");
        }
    }
}
