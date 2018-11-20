using System;
using System.Collections.Generic;

namespace GetSearchRanks.Models
{
    public interface ISearchResultsParser
    {
        List<WebResult> ParseHtmlToSearchResults(string htmlInput, string targetURL);
    }
}
