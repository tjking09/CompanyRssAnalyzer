using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRssAnalyzer
{
    class CompanyDictionaryClass
    {
        // Assuming we will have some companies with multiple RSS feeds, which we will store in a list inside the dictionary
        public Dictionary<string, List<string>> CompanyDictionary = new Dictionary<string, List<string>>();

        // Method to check for company inside dictionary and either add to existing list of RSS feeds, or create new dictionary entry
        public void Add(string key, string value)
        {
            if (this.CompanyDictionary.ContainsKey(key))
            {
                List<string> list = CompanyDictionary[key];
                if(list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(value);
                this.CompanyDictionary.Add(key, list);
            }
        }

    }
}
