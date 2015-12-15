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
using MovieJournalGateway;

namespace MovieJournal.Controllers
{
    public class HomeController : Controller
    {
        TMDBGateWayService tmdbGW = TMDBGateWayService.Instance;
        Facade facade = new Facade();
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
        
        [HttpGet]
        public ActionResult Search(string query)
        {
            var movielist = tmdbGW.SearchMovies(query);
            return View(movielist);
        }
        
        
        public ActionResult AddMovieOnList(int movieid)
        {
            //Finds ProfileId for the logged on user
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;
            var profile = facade.GetProfileGateWayService().GetByUserName(userName);

            // Checks if movie is already in users movie journal
            var moviesonlist = facade.GetMovieOnListRepository().GetByProfileId(profile.Id);
            Boolean movieExists = false;
            if(moviesonlist!=null)
            foreach(var item in moviesonlist)
            {
                    if (item.MovieId == movieid)
                    {
                        movieExists = true;
                        break;
                    }
            }

            if (!movieExists)
            {
                var addmovie = new MovieOnList() { MovieId = movieid, Rating = 0,Review="", ProfileId=profile.Id, Watched=false};
                facade.GetMovieOnListRepository().Add(addmovie);
                
            }
            return RedirectToAction("Index");

        }

    }
}