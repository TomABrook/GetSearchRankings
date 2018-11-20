using System;
namespace GetSearchRanks.Models

{
    // Object used to store infomation about an individual search result
    public class WebResult : Result
    {
        // Title of result page
        public string Title { get; set; }

        public WebResult(int rank, string url, string title) : base(rank, url)
        {
            this.Title = title;
            this.Type = Result.ResultType.Web;
        }
    }
}
