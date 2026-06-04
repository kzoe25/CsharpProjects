using System;

namespace EmployeeApp
{
    public class Employee
    {
        // Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            if (ReferenceEquals(emp1, null))
            {
                return ReferenceEquals(emp2, null);
            }
            if (ReferenceEquals(emp2, null))
            {
                return false;
            }

            return emp1.Id == emp2.Id;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee emp)
            {
                return this.Id == emp.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee
            {
                Id = 101,
                FirstName = "Jane",
                LastName = "Doe"
            };

            Employee employee2 = new Employee
            {
                Id = 101,
                FirstName = "John",
                LastName = "Smith"
            };

            Employee employee3 = new Employee
            {
                Id = 102,
                FirstName = "Alice",
                LastName = "Johnson"
            };

            Console.WriteLine($"Employee 1: ID = {employee1.Id}, Name = {employee1.FirstName} {employee1.LastName}");
            Console.WriteLine($"Employee 2: ID = {employee2.Id}, Name = {employee2.FirstName} {employee2.LastName}");
            Console.WriteLine($"Employee 3: ID = {employee3.Id}, Name = {employee3.FirstName} {employee3.LastName}");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Comparing Employee 1 and Employee 2 (Expected: True):");
            bool areEqual1And2 = (employee1 == employee2);
            Console.WriteLine($"employee1 == employee2: {areEqual1And2}\n");

            Console.WriteLine("Comparing Employee 1 and Employee 3 (Expected: False):");
            bool areEqual1And3 = (employee1 == employee3);
            Console.WriteLine($"employee1 == employee3: {areEqual1And3}\n");

            Console.WriteLine("Testing Inequality operator between Employee 1 and Employee 3 (Expected: True):");
            bool areNotEqual1And3 = (employee1 != employee3);
            Console.WriteLine($"employee1 != employee3: {areNotEqual1And3}");

            Console.ReadLine();
        }
    }
}