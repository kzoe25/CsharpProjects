using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sonic_FinalAssignment
{
    // The Sonic Student data model
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int TopSpeedMph { get; set; }
    }

    // The database connector context
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GreenHillHighDb;Trusted_Connection=True;");
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

                // Check if characters are already in the database
                if (!db.Students.Any())
                {
                    Console.WriteLine("Enrolling Sonic characters into Green Hill High...");

                    var student1 = new Student { FirstName = "Sonic the Hedgehog", Species = "Hedgehog", TopSpeedMph = 767 };
                    var student2 = new Student { FirstName = "Miles Tails Prower", Species = "Fox", TopSpeedMph = 150 };
                    var student3 = new Student { FirstName = "Knuckles the Echidna", Species = "Echidna", TopSpeedMph = 100 };

                    db.Students.Add(student1);
                    db.Students.Add(student2);
                    db.Students.Add(student3);
                    db.SaveChanges();

                    Console.WriteLine("Characters successfully enrolled!");
                }

                Console.WriteLine("\n--- Current Student Roster ---");

                var roster = db.Students.ToList();
                foreach (var s in roster)
                {
                    Console.WriteLine($"Name: {s.FirstName} | Species: {s.Species} | Top Speed: {s.TopSpeedMph} MPH (ID: {s.StudentId})");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}