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
    public class accController : Controller
    {
        // GET: acc
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register()
        {
            RegisterModel model = new RegisterModel {Email="hej@lol.dk", FirstName="navn", LastName="efternavn", Password="asdf1234", ConfirmPassword="asdf1234" };
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await AuthenticationService.Instance.PostAsync("/api/Account/Register", model);
                return View("Registered");
            }
            catch (AuthenticationException ex)
            {
                //No 200 OK result, what went wrong?

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                throw;
            }
        }
    }
}