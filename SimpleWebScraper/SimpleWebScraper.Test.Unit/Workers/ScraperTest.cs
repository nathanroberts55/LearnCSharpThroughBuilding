using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System;
using System.Text.RegularExpressions;

namespace SimpleWebScraper.Test.Unit
{
    [TestClass]
    public class ScraperTest
    {
        private readonly Scraper _scraper = new Scraper();

        [TestMethod]
        public void FindCollectionWithNoParts()
        {
            // Create fake content to have the scrape comb through
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            // Define the criteria the scraper is looking for
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .Build();

            // Have the found elements stored here
            var foundElements = _scraper.Scrape(scrapeCriteria);

            // The scraper should have one item  that is the entire line from content (as in won't find the description, just the link)
            Assert.IsTrue(foundElements.Count == 1);
            Assert.IsTrue(foundElements[0] == "<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a>");
        }

        [TestMethod]
        public void FindCollectionWithTwoParts()
        {
            // Define the content to be scraped again
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            // Define the scraper criteria, which is the link and the description
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@">(.*?)</a>")
                    .WithRegexOptions(RegexOptions.Singleline)
                    .Build())
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@"href=\""(.*?)\""")
                    .WithRegexOptions(RegexOptions.Singleline)
                    .Build())
                .Build();

            // Create a variable to hold the found elements
            var foundElements = _scraper.Scrape(scrapeCriteria);

            // Should contain multiple elements, containing both the link and description 
            Assert.IsTrue(foundElements.Count == 2);
            Assert.IsTrue(foundElements[0] == "some text");
            Assert.IsTrue(foundElements[1] == "http://domain.com");
        }
    }
}
