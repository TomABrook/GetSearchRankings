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

                // Set the search filters
                GoogleFilter filters = new GoogleFilter(Convert.ToInt32(numResults));

                // Object used to perform search queries and get parsed results
                GoogleSearch google = new GoogleSearch(filters);

                // Get results for query filtred by url
                List<WebResult> results = google.RunSearchQuery(searchTerms, targetURL);

                // A web exception was thrown
                if (results == null) {
                    ViewData["WebError"] = "A web error has occured";
                }

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

            return View();
        }

        public IActionResult Contact()
        {

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
