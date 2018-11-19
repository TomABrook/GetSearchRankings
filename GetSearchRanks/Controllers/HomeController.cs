using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetSearchRanks.Models;

namespace GetSearchRanks.Controllers
{
    public class HomeController : Controller
    {
        // Home Paage
        public IActionResult Index(string searchTerms, string targetURL, string numResults)
        {
            if (!string.IsNullOrEmpty(searchTerms)) { 
                // Object used to perform search queries and get parsed results
                GoogleSearch google = new GoogleSearch();

                // Set number of results to be searched to provided value
                google.numResults = Convert.ToInt32(numResults);

                // Get results for query filtred by url
                List<Result> results = google.RunSearchQuery(searchTerms, targetURL);

                // Pass data to view

                ViewData["Results"] = results;
                ViewData["ResultCount"] = results.Count;
                ViewData["TargetURL"] = targetURL;
                ViewData["NumResults"] = numResults;
                ViewData["Query"] = searchTerms;
            }

            return View();
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
