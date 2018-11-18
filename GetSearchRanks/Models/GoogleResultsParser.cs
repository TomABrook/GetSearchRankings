using System;
using System.Text.RegularExpressions;
namespace GetSearchRanks.Models

{
    // A class implementing the parser interface for google search results
    public class GoogleResultsParser : IParser
    {

        // Returns a list of unfiltered search results
        public Result[] ParseHtmlToSearchResults(string htmlInput) {

            // Check input is valid
            if (!string.IsNullOrEmpty(htmlInput))
            {
                string pattern = "<div class=\"g\">.*</div>";

                MatchCollection matches = Regex.Matches(htmlInput, pattern);
                System.Diagnostics.Debug.WriteLine("num matches = {0}", matches.Count);

                Result[] results = new Result[matches.Count];

                int i = 0;

                foreach (Match match in matches)
                {
                    System.Diagnostics.Debug.WriteLine("Match index = {0}", match.Index);

                    // Scrape for result url
                    Match urlMatch = Regex.Match(match.Value, "href=\"/url\\?q=(.*?)\"");

                    string urlString = urlMatch.Success ? urlString = urlMatch.Groups[1].Value : "";

                    // Scrape for result title
                    Match titleMatch = Regex.Match(match.Value, "<a.*?>(.*?)</a>");

                    string titleString = titleMatch.Success ? titleMatch.Groups[1].Value : "";

                    // Remove html from title
                    titleString = titleString.Replace("<br>", "");
                    titleString = titleString.Replace("</br>", "");

                    Result result = new Result(i+1, urlString, titleString);
                    results[i] = result;
                    i++;
                }

                return results;
            }
            else return null;
        }
    }
}
