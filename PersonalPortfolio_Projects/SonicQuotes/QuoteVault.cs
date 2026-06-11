using System;

namespace SonicQuotes
{
    public class QuoteVault
    {
        private string[] quotes = new string[]
        {
            // --- Sonic & Friends ---
            "\"An adventure is no fun if it's too easy!\" - Sonic the Hedgehog (Sonic Generations)",
            "\"I don't need a reason to help a friend!\" - Sonic the Hedgehog (Sonic Heroes)",
            "\"Nothing starts until you take action. If you've got time to worry, then run!\" - Sonic the Hedgehog (Sonic '06)",
            "\"I'm going to do my best!\" - Miles 'Tails' Prower (Sonic Adventure)",
            "\"As long as I can fight, I will always stand up!\" - Knuckles the Echidna (Sonic Adventure 2)",
            "\"I will protect the world, no matter the cost!\" - Blaze the Cat (Sonic Rush)",
            "\"The future isn't set in stone. We fight to shape it right now!\" - Silver the Hedgehog (Sonic Forces)",

            // --- Team Dark & Rival Lines ---
            "\"If the world chooses to become my enemy, I will fight like I always have!\" - Shadow the Hedgehog (Sonic '06)",
            "\"I am the ultimate life form!\" - Shadow the Hedgehog (Sonic Adventure 2)",
            "\"Worthless consumer models... I am E-123 Omega, the ultimate E-Series robot!\" - E-123 Omega (Sonic Heroes)",
            "\"We've got to find the computer room!\" - Vector the Crocodile (Shadow the Hedgehog)",

            // --- Modern Game Additions ---
            "\"I am the storyteller, and you are just a character in my book!\" - Erazor Djinn (Sonic and the Secret Rings)",
            "\"Get a load of this! All systems, full power!\" - Dr. Eggman (Sonic Adventure)"
        };

        private Random random = new Random();

        public string GetRandomQuote()
        {
            int index = random.Next(quotes.Length);
            return quotes[index];
        }
    }
}