using System;
using System.Text;

namespace SonicQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Keeps our custom star characters perfectly stable
            Console.OutputEncoding = Encoding.UTF8;

            // Call our separate quote bank file
            QuoteVault vault = new QuoteVault();
            bool running = true;

            Console.WriteLine(" ✧───*✧*───⊹───*✧*───⊹───*✧*───✧ ");
            Console.WriteLine(" ✧   🦔 Sonic Universe Quote Generator 🦔  ✧ ");
            Console.WriteLine(" ✧───*✧*───⊹───*✧*───⊹───*✧*───✧ ");

            while (running)
            {
                Console.WriteLine("\n⊹ Press ENTER to generate a random quote!");
                Console.WriteLine("⊹ Or type 'exit' to close the generator.");
                Console.Write("\nYour action: ");

                string input = Console.ReadLine() ?? string.Empty;

                if (input.ToLower() == "exit")
                {
                    running = false;
                }
                else
                {
                    // Fetch the quote from our separate file
                    string sonicQuote = vault.GetRandomQuote();

                    Console.WriteLine("\n⊹────────────────────────────────────────⊹");
                    Console.WriteLine($"  {sonicQuote}");
                    Console.WriteLine("⊹────────────────────────────────────────⊹");
                }
            }

            Console.WriteLine("\n ✧* Speed highway clear! Goodbye! Stay fast! *✧ ");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}