﻿using System;
using System.Net;
using System.Collections.Generic;

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

        // Used to parse results. Implementation will vary depending on search engine
        protected ISearchResultsParser parser;

        // protected WebProxy wp = new WebProxy("187.87.170.187", 23500);

        // Base URL of the search engine, to be combined with settings and search terms
        protected string baseURL;

        // Name of the search engine
        public string name;

        // Search filters to apply
        public SearchFilter Filters;

        // Construct a full search url by appending the base url, search query and filter options
        protected abstract string ConstructURL(string query);

        // Queries the string provided by the user in the search engine and 
        // returns an list of parsed results filtered by thtargetURL
        public abstract List<WebResult> RunSearchQuery(string query, string targetURL);

    }
}
