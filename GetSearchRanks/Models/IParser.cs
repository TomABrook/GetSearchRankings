using System;
namespace GetSearchRanks.Models
{
    public interface IParser
    {
        string ParseHtmlToSearchResults(string htmlInput);
    }
}
