using System;
using System.Collections.Generic;

namespace GetSearchRanks.Models
{
    public interface ISearchResultsParser
    {
        List<Result> ParseHtmlToSearchResults(string htmlInput, string targetURL);
    }
}
