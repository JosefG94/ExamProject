using MovieJournalBLL;
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
        MovieOnListBLL movbll = MovieOnListBLL.Instance;

        [HttpGet]
        public ActionResult MyJournal()
        {
            // Gets username
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;

            var profileid = facade.GetProfileGateWayService().GetByUserName(userName).Id;

            // Returns view with the list of movies for the specific user with the profileid
            return View(facade.GetMovieOnListRepository().GetByProfileId(profileid));
        }

        public ActionResult Index(string userName)
        {

            var profileid = facade.GetProfileGateWayService().GetByUserName(userName).Id;

            // Returns view with the list of movies for the specific user with the profileid
            return View(facade.GetMovieOnListRepository().GetByProfileId(profileid));
        }

        // Changes "Watched" to the opposite value of a MovieOnList
        public ActionResult EditWatched(int id)
        {
            var changedmov = movbll.ChangeWatched(facade.GetMovieOnListRepository().Get(id));
            facade.GetMovieOnListRepository().Edit(changedmov);
            return RedirectToAction("MyJournal");
        }

        // Changes rating of a MovieOnList
        public ActionResult EditRating(int id, int rating)
        {
            var changedmov = movbll.ChangeRating(facade.GetMovieOnListRepository().Get(id),rating);
            facade.GetMovieOnListRepository().Edit(changedmov);

            return RedirectToAction("MyJournal");
        }
        //  Changes the review of a MovieOnList
        public ActionResult EditReview(int id, string review)
        {
            var changedmov = movbll.ChangeReview(facade.GetMovieOnListRepository().Get(id), review);
            facade.GetMovieOnListRepository().Edit(changedmov);
            return RedirectToAction("MyJournal");
        }
        
        public ActionResult Delete(int id)
        {
            var delete = facade.GetMovieOnListRepository().Delete(id);
            return RedirectToAction("MyJournal");
        }

        
    }
}