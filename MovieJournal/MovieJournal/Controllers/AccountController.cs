using MovieJournalDTO.AuthModels;
using MovieJournalGateway.AuthServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                return View("RegisterSuccessful", model);
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

        // GET: Account/SignIn
        public ActionResult SignIn(string returnUrl)
        {
            Session["RedirectUrl"] = returnUrl;
            return View();
        }

        // POST: Account/SignIn
        [HttpPost]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //Find if there is a redirect Url. Then remove it for next time!
                var redirectUrl = Session["RedirectUrl"] as string;
                Session["RedirectUrl"] = null;
                var result = await aservice.AuthenticateAsync<SignInResult>(model.UserName, model.Password);
                var userInfo = await aservice.GetAsync<UserModel>("/api/Account/UserInfo", result.AccessToken);
                userInfo.Token = result.AccessToken;
                string json = JsonConvert.SerializeObject(userInfo);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), model.RememberMe, json, "/");
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);

                    return Redirect(redirectUrl ?? "/");
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

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}