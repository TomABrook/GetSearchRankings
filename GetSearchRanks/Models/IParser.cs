using System;
namespace GetSearchRanks.Models
{
    public interface IParser
    {
        Result[] ParseHtmlToSearchResults(string htmlInput);
    }
}
