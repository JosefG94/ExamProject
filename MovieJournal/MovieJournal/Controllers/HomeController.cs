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
        public ActionResult Index()
        {
            return View(hej.GetPopular());
        }


    }
}