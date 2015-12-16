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
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var profile = facade.GetProfileGateWayService().GetByUserName(userName);
            return View(facade.GetMovieOnListRepository().GetByProfileId(profile.Id));
        }
    }
}