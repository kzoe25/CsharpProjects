using System;

namespace PackageExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            Console.Write("Please enter the package weight: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return; // End the program if it's too heavy
            }

            Console.Write("Please enter the package width: ");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter the package height: ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter the package length: ");
            double length = Convert.ToDouble(Console.ReadLine());

            double totalDimensions = width + height + length;

            if (totalDimensions > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return; // End the program if it's too big
            }

            double quote = (width * height * length * weight) / 100;

            Console.WriteLine($"Your estimated total for shipping this package is: {quote:C}");
            Console.WriteLine("Thank you!");
        }
    }
}