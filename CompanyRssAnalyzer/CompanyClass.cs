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
        public List<string> FindInactiveCompanies(Dictionary<string, List<string>> companyDictionary, int daysBack)
        {
            // Initialize new list to store companies without recent activity]
            List<string> InactiveCompanies = new List<string>();

            // Set date check to go back in time
            daysBack *= -1;
            DateTime checkDate = DateTime.Now.AddDays(daysBack);

            // Remove - used for debugging
            Console.WriteLine($"Check Date: {checkDate}");

            // iterate through the dictionary to determine whether the feeds have recent activity
            foreach (KeyValuePair<string, List<string>> entry in companyDictionary)
            {
                for (int i = 0; i < companyDictionary.Values.Count; i++)
                {
                    // Start reading RSS XML
                    XmlReader reader = XmlReader.Create(entry.Value[i]);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    reader.Close();

                    // Print company name for debugging purposes
                    Console.WriteLine($"\n{entry.Key}");

                    // Run through the RSS feed items
                    foreach (SyndicationItem item in feed.Items)
                    {
                        // Grab the date of the most recent published item
                        DateTime lastUpdated = item.PublishDate.Date;

                        // Determine whether the last publish date is within our check date
                        if (lastUpdated != null)
                        {
                            Console.WriteLine($"Last Updated: {lastUpdated}");
                            if (lastUpdated > checkDate)
                            {
                                Console.WriteLine("It is up to date");
                            }
                            else
                            {
                                Console.WriteLine("It hasn't been updated lately");
                                InactiveCompanies.Add(entry.Key);
                            }
                            break;
                        }
                    }
                }
            }
            return InactiveCompanies;
        }
    }
}
