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
        Facade facade = new Facade();
        MovieOnListBLL movbll = MovieOnListBLL.Instance;

        // Outputs Movie Journal of currently logged user, with (C)RUD functionality
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

        // Outputs Movie Journal for searched user
        public ActionResult Index(string userName)
        {
            var profile = facade.GetProfileGateWayService().GetByUserName(userName);
            // If User Name does not exist, return this view
            if (profile == null)
                return View("NoProfileFound", model:userName);
            // Returns view with the list of movies for the specific user with the profileid
            return View(facade.GetMovieOnListRepository().GetByProfileId(profile.Id));
        }

        // Changes "Watched" to the opposite value of a MovieOnList
        public ActionResult EditWatched(int id)
        {
            // Gets username
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;

            var changedmov = movbll.ChangeWatched(facade.GetMovieOnListRepository().Get(id));

            var userValidate = facade.GetProfileGateWayService().GetByUserName(userName);
            if (userValidate == null || (changedmov.ProfileId != userValidate.Id))
                return View("NoAuthorization");

            facade.GetMovieOnListRepository().Edit(changedmov);
            return RedirectToAction("MyJournal");
        }

        // Changes rating of a MovieOnList
        public ActionResult EditRating(int id, int rating)
        {
            // Gets username
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;

            var changedmov = movbll.ChangeRating(facade.GetMovieOnListRepository().Get(id),rating);
            // If ProfileId of the MovieOnList does not equal Profile Id for the logged in account, return the NoAuthorization view
            var userValidate = facade.GetProfileGateWayService().GetByUserName(userName);
            if (userValidate == null || (changedmov.ProfileId != userValidate.Id))
                return View("NoAuthorization");

            facade.GetMovieOnListRepository().Edit(changedmov);
            return RedirectToAction("MyJournal");
        }
        //  Changes the review of a MovieOnList
        public ActionResult EditReview(int id, string review)
        {
            // Gets username
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;

            var changedmov = movbll.ChangeReview(facade.GetMovieOnListRepository().Get(id), review);

            // If ProfileId of the MovieOnList does not equal Profile Id for the logged in account, return the NoAuthorization view
            var userValidate = facade.GetProfileGateWayService().GetByUserName(userName);
            if (userValidate == null ||(changedmov.ProfileId != userValidate.Id))
                return View("NoAuthorization");

            facade.GetMovieOnListRepository().Edit(changedmov);
            return RedirectToAction("MyJournal");
        }
        
        public ActionResult Delete(int id)
        {
            // Gets username
            var user = System.Threading.Thread.CurrentPrincipal;
            var userName = user.Identity.Name;

            // If ProfileId of the MovieOnList does not equal Profile Id for the logged in account, return the NoAuthorization view
            var userValidate = facade.GetProfileGateWayService().GetByUserName(userName);
            if (userValidate == null || facade.GetMovieOnListRepository().Get(id).ProfileId !=userValidate.Id)
                return View("NoAuthorization");

            var delete = facade.GetMovieOnListRepository().Delete(id);
            return RedirectToAction("MyJournal");
        }

        
    }
}