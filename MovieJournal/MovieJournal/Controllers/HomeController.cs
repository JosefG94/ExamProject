using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TMDBGateway.TMDBServices;

namespace MovieJournal.Controllers
{
    public class HomeController : Controller
    {
        TMDBGateWayService hej = new TMDBGateWayService();
      /*  public ActionResult Index()
        {
            return View(hej.GetPopular());
        }*/

        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&api_key=1396960c122fb1696773a4d42f994866");

                string content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<MovieJournalDTO.Movie>(content);
                    return View(model);
                }

                // an error occurred => here you could log the content returned by the remote server
                return Content("An error occurred: " + content);
            }
        }

    }
}