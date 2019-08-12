using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace CompanyRssAnalyzer
{
    class CompanyClass
    {
        public List<string> FindInactiveCompanies(Dictionary<string, List<string>> companyDictionary, int daysBack)
        {
            // Initialize new list to store companies without recent activity
            List<string> InactiveCompanies = new List<string>();

            // Set date check to go back in time
            daysBack *= -1;
            DateTime checkDate = DateTime.Now.AddDays(daysBack);

            // iterate through the dictionary to determine whether the feeds have recent activity
            foreach (KeyValuePair<string, List<string>> entry in companyDictionary)
            {
                for (int i = 0; i < companyDictionary.Values.Count; i++)
                {
                    // Start reading RSS XML
                    XmlReader reader = XmlReader.Create(entry.Value[i]);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    reader.Close();

                    // Run through the RSS feed items
                    foreach (SyndicationItem item in feed.Items)
                    {
                        // Grab the date of the most recent published item
                        DateTime lastUpdated = item.PublishDate.Date;

                        // Determine whether the last publish date is within our check date
                        if (lastUpdated != null)
                        {
                            // Console.WriteLine($"Last Updated: {lastUpdated}");

                            if (lastUpdated > checkDate)
                            {
                                // Don't do anything - move to next company
                            }
                            else
                            {
                                // Add company to list of return values
                                InactiveCompanies.Add(entry.Key);
                            }
                            break; // Take most recent, non null item
                        }
                    }
                }
            }

            return InactiveCompanies;
        }
    }
}
