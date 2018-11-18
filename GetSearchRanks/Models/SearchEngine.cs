using System;
using System.Net;

namespace GetSearchRanks.Models

{
    /*
     * Abstract class for search engines, implements basic shared attributes of 
     * different search engines. Used as base class for search engine class that 
     * will be used to perform queries on search terms provided by the user
     */
    public abstract class SearchEngine
    {
        // This object can be used to download data from the web
        protected WebClient webclient = new WebClient();

        // protected WebProxy wp = new WebProxy("187.87.170.187", 23500);

        // Base URL of the search engine, to be combined with settings and search terms
        protected string baseURL;

        // The number of results requested by user
        public int numResults { get; set; }

        // Name of the search engine
        public string name;

        // Takes a query string provided by the user and returns the search results page
        // for this query in html format
        public abstract string RunSearchQuery(string query);

    }
}
