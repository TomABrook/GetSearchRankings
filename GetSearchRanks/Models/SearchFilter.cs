using System;
namespace GetSearchRanks.Models
{
    /* The range and implementation of search filters varies accroding to the search
     * engine being used. Extend this class to provide basic filters and search engine
     * specific filters */
    public abstract class SearchFilter
    {
        // Standard options
        public int NumResults { set; get; }
        protected string TimePeriod;

        /* Number of results must always be supplied to limit search results
         * as searching the full range of reuslts can quickly result in  temporary IP block
         * by search provider */
        protected SearchFilter(int NumResults)
        {
            this.NumResults = NumResults;
        }

        /* Returns the options that are available for searching a specific time period
        * that will be displayed to the User to select */
        public abstract string[] TimePeriodOptions();

        /* Saves the users filter selection as the correct url component as defined by 
         * the search engine, eg "year" -> "y" */
        public abstract void SetTimePeriod(string selection);
    }
}
