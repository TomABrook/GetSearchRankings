using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Xunit;
using GetSearchRanks.Models;

namespace GetSearchRanksTest
{
    public class UnitTest1
    {
        [Fact]
        public void GoogleParserTest()
        {
            // given...
            GoogleSearch google = new GoogleSearch();
            GoogleResultsParser parser = new GoogleResultsParser();
            string currentpath = Directory.GetCurrentDirectory();
            string testProjectPath = Path.GetFullPath(Path.Combine(currentpath, @"../../../"));
            string testFilePath = Path.Combine(testProjectPath, "GoogleResultsTestHtml.txt");
            string testHtml = File.ReadAllText(testFilePath, Encoding.UTF8);

            // when...
            List<Result> results = google.RunSearchQuery("infotrack", "infotrack");

            // then...
            Assert.Equal("InfoTrack", results[0].title);
            Assert.Equal(3, results.Count);
            Assert.Equal(1, results[0].rank);
            Assert.Equal(3, results[2].rank);
            Assert.Equal("InfoTrack", results[0].title);
            Assert.Equal("Conveyancing Searches - InfoTrack | LEAP UK", results[1].title);
        }
    }

}
