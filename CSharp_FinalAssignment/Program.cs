using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalAssignment
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentDb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                // Creates the database automatically
                db.Database.EnsureCreated();

                Console.WriteLine("Adding a new student...");

                var student = new Student { FirstName = "Jane", LastName = "Doe" };

                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine("Student saved successfully!");

                var query = db.Students.ToList();
                foreach (var s in query)
                {
                    Console.WriteLine($"Found Student: {s.FirstName} {s.LastName} (ID: {s.StudentId})");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}