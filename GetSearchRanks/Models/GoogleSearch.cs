using System;
using System.Web;
using System.Net;
using System.Collections.Generic;

namespace GetSearchRanks.Models

{
    public class GoogleSearch : SearchEngine
    {
        public GoogleSearch()
        {
            name = "Google";
            baseURL = "https://www.google.co.uk/search";
            numResults = 3;
            parser = new GoogleResultsParser();

            // webclient.Proxy = this.wp;
        }


        // Runs a google search on query and returns results filtered by targetURL
        public override List<Result> RunSearchQuery(string query, string targetURL)
        {
            // Spaces aren't valid in google search url
            query.Replace(' ', '+');
            System.Diagnostics.Debug.WriteLine(query);

            // Construct query
            string queryURL = baseURL + "?num=" + numResults + "&q=" + query;

            try
            {
                // Perfrom search query, obtaining search results html
                string webpage = webclient.DownloadString(queryURL);

                // Return html as a parsed set

                return parser.ParseHtmlToSearchResults(webpage, targetURL);

            }
            catch (WebException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
