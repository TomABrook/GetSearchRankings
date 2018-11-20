using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Xunit;
using GetSearchRanks.Models;

namespace GetSearchRanksTest
{
    public class UnitTests
    {
        // Test google parser on a html dump from results page
        [Fact]
        public void GoogleParserTest()
        {
            // given...
            GoogleFilter filter = new GoogleFilter(5);
            GoogleSearch google = new GoogleSearch(filter);
            GoogleResultsParser parser = new GoogleResultsParser();

            // open file
            string currentpath = Directory.GetCurrentDirectory();
            string testProjectPath = Path.GetFullPath(Path.Combine(currentpath, @"../../../"));
            string testFilePath = Path.Combine(testProjectPath, "GoogleResultsTestHtml.txt");
            string testHtml = File.ReadAllText(testFilePath, Encoding.UTF8);

            // when...
            List<WebResult> results = parser.ParseHtmlToSearchResults(testHtml, "info");

            // then...
            Assert.Equal(3, results.Count);
            Assert.Equal("https://www.infotrack.co.uk/", results[0].Url);
            Assert.Equal(1, results[0].Rank);
            Assert.Equal(3, results[2].Rank);
            Assert.Equal("InfoTrack", results[0].Title);
            Assert.Equal("Conveyancing Searches - InfoTrack | LEAP UK", results[1].Title);
        }


        // Test Google filter
        [Fact]
        public void TestGoogleFilter() {
            // Given...
            GoogleFilter filter = new GoogleFilter(5);

            // When...
            filter.SetTimePeriod("Year");

            // Then...
            Assert.Equal("y", filter.GetTimePeriod());
        }
    }

}
