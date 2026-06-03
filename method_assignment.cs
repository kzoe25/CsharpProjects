using System;

namespace methodAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            mathOperations mathObj = new mathOperations();

            mathObj.DisplayNumbers(10, 15);
            
            mathObj.DisplayNumbers(Number1: 15, Number2: 9);

            Console.ReadLine();
        }
    }

    public class mathOperations
    {
        public void DisplayNumbers(int Number1, int Number2)
        {
            int result = Number1 * 5;

            Console.WriteLine($"The value of the second parameter is: {Number2}");
        }
    }
}