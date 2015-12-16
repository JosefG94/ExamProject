using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieJournalDTO;

namespace MovieJournalGateway.Services
{
    public class ProfileGateWayService : IGateWayService<Profile>
    {
        public IEnumerable<Profile> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:30332/api/profile/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Profile>>().Result;
            }
        }
        public Profile Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:30332/api/profile/" + id).Result;
                return response.Content.ReadAsAsync<Profile>().Result;
            }
        }

        public Profile GetByUserName(string userName)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:30332/api/UserName?userName=" + userName).Result;
                return response.Content.ReadAsAsync<Profile>().Result;
            }
        }

        public Profile Add(Profile profile)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:30332/api/profile/", profile).Result;
                return response.Content.ReadAsAsync<Profile>().Result;
            }
        }

        public Profile Edit(Profile profile)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:30332/api/profile/", profile).Result;
                return response.Content.ReadAsAsync<Profile>().Result;
            }
        }

        public Profile Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:30332/api/profile/" + id).Result;
                return response.Content.ReadAsAsync<Profile>().Result;
            }
        }
    }
}


