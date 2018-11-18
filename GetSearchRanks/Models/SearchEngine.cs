using System;
using System.Net;

namespace GetSearchRanks.Models

{
    public abstract class SearchEngine
    {
        protected WebClient webclient = new WebClient();
        protected string baseURL;

        public int numResults { get; set; }
        public string name;

        public abstract string RunSearchQuery(string query);

    }
}
