using System;
using System.Web;
using System.Net;
using System.Collections.Generic;

namespace GetSearchRanks.Models

{
    public class GoogleSearch : SearchEngine
    {
        public GoogleSearch(GoogleFilter filters)
        {
            name = "Google";
            baseURL = "https://www.google.co.uk/search";

            // Set user provided filters
            this.Filters = filters;

            parser = new GoogleResultsParser();

            // webclient.Proxy = this.wp;
        }

        // Create full search url
        protected override string ConstructURL(string query)
        {
            // Spaces aren't valid in google search url
            query.Replace(' ', '+');
            System.Diagnostics.Debug.WriteLine(query);

            // Get filters
            int numResults = this.Filters.NumResults;

            // Construct url
            string fullURL = baseURL + "?num=" + numResults + "&q=" + query;

            return fullURL;

        }


        // Runs a google search on query and returns results filtered by targetURL
        public override List<WebResult> RunSearchQuery(string query, string targetURL)
        {
            string fullURL = ConstructURL(query);

            try
            {
                // Perfrom search query, obtaining search results html
                string webpage = webclient.DownloadString(fullURL);

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
