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
            var userName = facade.GetProfileGateWayService().GetTEST();
            var profile = facade.GetProfileGateWayService().GetByUserName(userName.UserName);
            return View(facade.GetMovieOnListRepository().GetByProfileId(profile.Id));
        }
    }
}