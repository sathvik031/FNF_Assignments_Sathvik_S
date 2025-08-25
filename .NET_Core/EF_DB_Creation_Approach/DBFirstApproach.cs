using DotnetCoreAssignment.DATA;
using System;

namespace DotnetCoreAssignment
{
    internal class DBFirstApproach
    {
        static void Main(string[] args)
        {
            try
            {
                var dbContext = new StudentContext();
                var newStudent = new Student
                {
                    StudentName = "Sachin",
                    Course = "Electronics",
                    Marks = 85
                };
                dbContext.Students.Add(newStudent);
                dbContext.SaveChanges();
                Console.WriteLine("Student inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
