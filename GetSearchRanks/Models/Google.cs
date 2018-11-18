using System;
using System.Web;
using System.Net;

namespace GetSearchRanks.Models

{
    public class Google : SearchEngine
    {
        public Google()
        {
            name = "Google";
            baseURL = "https://www.google.co.uk/search";
            numResults = 3;

            // webclient.Proxy = this.wp;
        }

        public override string RunSearchQuery(string query) {

            query.Replace(' ', '+');
            System.Diagnostics.Debug.WriteLine(query);

            string queryURL = baseURL + "?num=" + numResults + "&q=" + query;

            try {
                return webclient.DownloadString(queryURL);
            } catch (WebException e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
