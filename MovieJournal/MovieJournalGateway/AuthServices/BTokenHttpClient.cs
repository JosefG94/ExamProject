using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Web;
using System.Web.Security;
using MovieJournalDTO.AuthModels;

namespace MovieJournalGateway.AuthServices
{
    class BTokenHttpClient : HttpClient
    {
        public BTokenHttpClient()
        {
            SetToken();
        }

        private void SetToken()
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (authTicket == null) return;

            var model = JsonConvert.DeserializeObject<UserModel>(authTicket.UserData);

            if (model != null && !model.Token.IsNullOrWhiteSpace())
            {
                //Add the authorization header
                DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + model.Token);
            }
        }
    }

}
