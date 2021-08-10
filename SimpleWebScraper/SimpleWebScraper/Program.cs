using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper
{
    class Program
    {

        private const string Method = "search";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please Enter Which City you would like to search: ");
                var craigsListCity = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Please Enter the Craiglist Category you would like to search: ");
                var craigsListCategory = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    // Download the web page, from the link constructed with the input from the user
                    string content = client.DownloadString($"https://{craigsListCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{craigsListCategory}");

                    // Build a scrape criteria for the page
                    // Give it the content of the page that was downloaded
                    // The, get the content from the a tags, followed but the content between the a tags (the description)
                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                         .WithData(content)
                        // craigslist recently added an id to their group elements which I have included here as an update - 10/5/2020
                        .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"" id=\""(.*?)\"" >(.*?)</a>")
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

                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var element in scrapedElements)
                        {
                            Console.WriteLine(element);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the scrape Criteria specified ");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
