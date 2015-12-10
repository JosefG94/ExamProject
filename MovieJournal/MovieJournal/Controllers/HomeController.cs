using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TMDBGateway.TMDBServices;
using MovieJournalDTO;

namespace MovieJournal.Controllers
{
    public class HomeController : Controller
    {
        TMDBGateWayService tmdbGW = TMDBGateWayService.Instance;
        public ActionResult Index()
        {
            return View(tmdbGW.GetPopular());
        }

        [HttpGet]
        public ActionResult GetMovie(int id)
        {
            var movie = tmdbGW.GetMovie(id);
            return View(movie);
        }


    }
}