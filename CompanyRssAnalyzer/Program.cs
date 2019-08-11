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
            // Set variable for how many days back we want to check for activity
            int daysBack = 2;

            // initialize our company class instance that will include method to determine company activity
            var instance = new CompanyClass();

            // Company Dictionary decloration
            Dictionary<string, string> CompanyDictionary = new Dictionary<string, string>
            {
                { "ESPN", "https://www.espn.com/espn/rss/news" },
                { "Bill Simmons Podcast", "https://rss.art19.com/the-bill-simmons-podcast" },
                { "Hacker News", "https://hnrss.org/newest" }
            };

            // Remove before submission - used for debugging
            Console.ReadLine();
        }
    }
}
