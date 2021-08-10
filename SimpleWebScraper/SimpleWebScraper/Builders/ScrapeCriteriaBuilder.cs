using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// 
/// Builder Class for the Scrape Criteria Class
/// 
/// Has method to set default the values
/// Also methods to add to the individual values
/// 
/// </summary>
namespace SimpleWebScraper.Builders
{
    class ScrapeCriteriaBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaPart> _parts;

        // Constructor that calls the SetDefault method on creation.
        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }
        // Sets the Default values of all the properities to emptty (or the empty equivalent)
        private void SetDefaults()
        {
            _data = string.Empty;
            _regex =string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();
        }
        // Allow to set the data. Returns the current object
        public ScrapeCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }
        // Allow to set the regex. Returns the current object
        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        // Allow to set the regex options. Returns the current object
        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }
        // Allow to set the parts. Returns the current object
        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _parts.Add(scrapeCriteriaPart);
            return this;
        }

        public ScrapeCriteria Build()
        {
            // Create the ScrapeCriteria object
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();

            // Set the values of the values of the new object
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOption = _regexOption;
            scrapeCriteria.Parts = _parts;

            // Return the scrapeCriteria object
            return scrapeCriteria;
        }
    }
}
