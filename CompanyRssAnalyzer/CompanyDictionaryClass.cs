using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRssAnalyzer
{
    class CompanyDictionaryClass
    {
        public Dictionary<string, List<string>> CompanyDictionary = new Dictionary<string, List<string>>();

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
