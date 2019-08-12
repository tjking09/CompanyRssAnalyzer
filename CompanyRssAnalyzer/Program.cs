using System;
using System.Collections.Generic;

namespace CompanyRssAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set variable for how many days back, from today, we want to check for activity
            int daysBack = 2;

            // initialize our company class instance that will include method to determine company activity
            var instance = new CompanyClass();
            var dictionaryInstance = new CompanyDictionaryClass();

            // Debugging purposes to check dictionary functionality
            dictionaryInstance.Add("ESPN", "https://www.espn.com/espn/rss/nhl/news");

            // Call method in CompanyClass to determine which companies have not published without our set check period
            List<string> results = new List<string>();
            results = instance.FindInactiveCompanies(dictionaryInstance.CompanyDictionary, daysBack);


            Console.WriteLine($"List of Companies:");
            foreach (var r in results)
            {
                Console.WriteLine($"{r}\n");
            }

            // Remove before submission - used for debugging
            Console.ReadLine();
        }
    }
}
