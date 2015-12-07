using MovieJournalDAL;
using MovieJournalDTO.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MovieJournalDAL.Repository;
using MovieJournalDTO;
using MovieJournalDTO.Converter;
using System.Data.Entity;
using System.Net.Http;
using System.Net;
using MovieJournalDAL.Model;

namespace MovieJournalAPI.Controllers
{
    public class MovieOnListController : ApiController
    {
        Facade facade = new Facade();

        /// <summary>
        /// Will get all MovieOnList from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MovieOnListDTO> GetAll()
        {
            var movieOnList = facade.GetMovieOnListRepository().ReadAll();
            return new MovieOnListDTOConverter().Convert(movieOnList);
        }

        /// <summary>
        /// Will get a specific MovieOnList found by the Id
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Get(int Id)
        {
            var movieOnList = facade.GetMovieOnListRepository().Get(Id);
            MovieOnListDTO movieOnListDTO = null;
            if (movieOnList != null)
            {
                movieOnListDTO = new MovieOnListDTOConverter().Convert(movieOnList);
                return Request.CreateResponse<MovieOnListDTO>(HttpStatusCode.OK, movieOnListDTO);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(" MovieOnList not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a MovieOnList in the Database
        /// </summary>
        /// <param name="movieOnList"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(MovieOnList movieOnList)
        {
            try
            {
                var movieOnListDTO = new MovieOnListDTOConverter().Convert(movieOnList);
                facade.GetMovieOnListRepository().Add(movieOnList);

                var response = Request.CreateResponse<MovieOnListDTO>(HttpStatusCode.Created, movieOnListDTO);
                var uri = Url.Link("GetMovieOnListById", new { movieOnList.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a movieOnList to the database")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Updates a MovieOnList in Database
        /// </summary>
        /// <param name="movieOnList"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(MovieOnList movieOnList)
        {
            try
            {
                var movieOnListDTO = new MovieOnListDTOConverter().Convert(movieOnList);
                facade.GetMovieOnListRepository().Edit(movieOnList);
                var response = Request.CreateResponse<MovieOnListDTO>(HttpStatusCode.OK, movieOnListDTO);
                var uri = Url.Link("GetMovieOnListById", new { movieOnList.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching movieOnList")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Delete a MovieOnList in database
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
            facade.GetMovieOnListRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}



