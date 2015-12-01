using MovieJournalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalGateway.Services
{
    public class MovieOnListGateWayService : IGateWayService<MovieOnList>
    {
        public IEnumerable<MovieOnList> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:30332/api/movieOnList/").Result;
                return response.Content.ReadAsAsync<IEnumerable<MovieOnList>>().Result;
            }
        }
        public MovieOnList Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:30332/api/movieOnList/" + id).Result;
                return response.Content.ReadAsAsync<MovieOnList>().Result;
            }
        }

        public MovieOnList Add(MovieOnList movieOnList)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:30332/api/movieOnList/", movieOnList).Result;
                return response.Content.ReadAsAsync<MovieOnList>().Result;
            }
        }

        public MovieOnList Edit(MovieOnList movieOnList)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:30332/api/movieOnList/", movieOnList).Result;
                return response.Content.ReadAsAsync<MovieOnList>().Result;
            }
        }

        public MovieOnList Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:30332/api/movieOnList/" + id).Result;
                return response.Content.ReadAsAsync<MovieOnList>().Result;
            }
        }
    }
}


