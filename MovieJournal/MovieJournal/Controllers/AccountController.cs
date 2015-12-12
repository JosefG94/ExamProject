using MovieJournalDTO.AuthModels;
using MovieJournalGateway.AuthServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieJournal.Controllers
{
    public class AccountController : Controller
    {

        AuthenticationService aservice = AuthenticationService.Instance;
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await aservice.PostAsync("/api/Account/Register", model);
                return View("Registered");
            }
            catch (AuthenticationException ex)
            {
                //No 200 OK result, what went wrong?
                //HandleBadRequest(ex);

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                throw;
            }
        }
    }
}