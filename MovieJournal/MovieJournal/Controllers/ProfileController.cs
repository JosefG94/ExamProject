using MovieJournalGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieJournal.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        Facade facade = new Facade();
        
        public ActionResult Index()
        {
            // Gets username
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;

            var profileid = facade.GetProfileGateWayService().GetByUserName(userName).Id;

            // Returns view with the list of movies for the specific user with the profileid
            return View(facade.GetMovieOnListRepository().GetByProfileId(profileid));
        }
    }
}