using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompanyRssAnalyzer;

/* 
 * Not too familiar with unit testing, 
 * and was unable to get the method references to operate correctly
 */

namespace CompanyRssAnalyzer_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CompanyDictionaryClass.Add("ESPN", "https://www.espn.com/espn/rss/nhl/news");
            CompanyClass.FindInactiveCompanies();
        }
    }
}
