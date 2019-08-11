using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            dictionaryInstance.Add("ESPN", "https://www.espn.com/espn/rss/nhl/news");

            // Call method in CompanyClass to determine which companies have not published without our set check period
            instance.FindInactiveCompanies(dictionaryInstance.CompanyDictionary, daysBack); 

            // Remove before submission - used for debugging
            Console.ReadLine();
        }
    }
}
