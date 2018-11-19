using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace GetSearchRanks.Models

{
    // A class implementing the parser interface for google search results
    public class GoogleResultsParser : ISearchResultsParser
    {
        // Returns a list of filtered search results, or unfiltered if no url is supplied
        public List<Result> ParseHtmlToSearchResults(string htmlInput, string targetURL ="") {

            // Check input is valid
            if (!string.IsNullOrEmpty(htmlInput))
            {
                // Pattern to match html capturing a single result on google results page
                string pattern = "<div class=\"g\">.*</div>";

                MatchCollection matches = Regex.Matches(htmlInput, pattern);

                // debug msg
                System.Diagnostics.Debug.WriteLine("num matches = {0}", matches.Count);

                // Results here to be returned
                List<Result> results = new List<Result>();

                // No search rank value in html data so this variable will be used
                int rank = 1;

                // Loop through all search results
                foreach (Match match in matches)
                {
                    System.Diagnostics.Debug.WriteLine("Match index = {0}", match.Index);

                    // Scrape for result url
                    Match urlMatch = Regex.Match(match.Value, "href=\"/url\\?q=(.*?)&amp");

                    string urlString = urlMatch.Success ? urlString = urlMatch.Groups[1].Value : "";

                    // Check against target. If not target was supplied then process all
                    if (targetURL != "" && !urlString.Contains(targetURL)) {

                        rank++;
                        continue;
                    }

                    // Scrape for result title
                    Match titleMatch = Regex.Match(match.Value, "<a.*?>(.*?)</a>");

                    string titleString = titleMatch.Success ? titleMatch.Groups[1].Value : "";

                    // Remove html from title
                    titleString = Regex.Replace(titleString, "<.*?>", String.Empty);

                    // In some cases an image widge will be matched, this check is to remove it from results
                    if (!String.IsNullOrEmpty(titleString))
                    {
                        Result result = new Result(rank, urlString, titleString);
                        results.Add(result);
                    }
                    rank++;
                }

                return results;
            }
            // Input was invalid
            else return null;
        }
    }
}
