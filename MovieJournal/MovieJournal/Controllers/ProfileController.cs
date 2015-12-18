using MovieJournalDTO;
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

        // Changes "Watched" to the opposite value of a MovieOnList
        public ActionResult EditWatched(int id, Boolean watched)
        {
            var before = facade.GetMovieOnListRepository().Get(id);
            before.Watched = watched;
            var after = facade.GetMovieOnListRepository().Edit(before);
            return RedirectToAction("Index");
        }

        // Changes rating of a MovieOnList
        public ActionResult EditRating(int id, int rating)
        {
            var before = facade.GetMovieOnListRepository().Get(id);
            before.Rating = rating;
            var after = facade.GetMovieOnListRepository().Edit(before);
            return RedirectToAction("Index");
        }
        //  Changes the review of a MovieOnList
        public ActionResult EditReview(int id, string review)
        {
            var before = facade.GetMovieOnListRepository().Get(id);
            before.Review = review;
            var after = facade.GetMovieOnListRepository().Edit(before);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delete = facade.GetMovieOnListRepository().Delete(id);
            return RedirectToAction("Index");
        }
    }
}