using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CompanyRssAnalyzer
{
    class CompanyClass
    {
        public void FindInactiveCompanies(Dictionary<string, string> companyDictionary, int daysBack)
        {
            // Set date check to go back in time
            daysBack *= -1;
            DateTime checkDate = DateTime.Now.AddDays(daysBack);

            // Remove - used for debugging
            Console.WriteLine($"Check Date: {checkDate}");

            // iterate through the dictionary to determine whether the feeds have recent activity
            foreach (KeyValuePair<string, string> entry in companyDictionary)
            {
                // Start reading RSS XML
                XmlReader reader = XmlReader.Create(entry.Value);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                // Print company name for debugging purposes
                Console.WriteLine($"\n{entry.Key}");
            }
        }
    }
}
