using System;
using System.Diagnostics;
using IQuittableApp;

namespace IQuittableApp
{
    public interface IQuittable
    {
        void Quit();
    }

    public class Employee : IQuittable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public void Quit()
        {
            Console.WriteLine($"{firstName} {lastName} has resigned from the company.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee() { firstName = "Jane", lastName = "Doe" };

        IQuittable quitter = employee;

        quitter.Quit();

        Console.ReadLine();
    }
}