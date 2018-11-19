using System;
namespace GetSearchRanks.Models

{
    // Object used to store infomation about an individual search result
    public class Result
    {
        // Where the result appears in descending order
        public int rank { get; set; }

        // The url link of the result
        public string url { get; set; }

        // Title of result page
        public string title { get; set; }

        public Result(int rank, string url, string title)
        {
            this.rank = rank;
            this.url = url;
            this.title = title;
        }
    }
}
