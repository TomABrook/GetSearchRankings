using System;
namespace GetSearchRanks.Models
{
    public class Google : SearchEngine
    {
        public Google()
        {
            name = "Google";
            baseURL = "https://www.google.co.uk/search?";
            numResults = 100;
        }

        public override string RunSearchQuery(string query) {

            string queryURL = baseURL + "num=" + numResults + "&q=" + query;

            return webclient.DownloadString(queryURL);
        }
    }
}
