using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MovieJournalDAL.Repository;
using MovieJournalDAL;
using MovieJournalDAL.Model;
using MovieJournalDTO.Converter;
using MovieJournalDTO.ModelDTO;
using MovieJournalDTO;

namespace MovieJournalAPI.Controllers
{
    public class ProfileController : ApiController
    {
        Facade facade = new Facade();

        /// <summary>
        /// Will get all Profile from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProfileDTO> GetAll()
        {
            var profile =  facade.GetProfileRepository().ReadAll();
            return new ProfileConverter().Convert(profile);
        }
        /// <summary>
        /// Will get a specific Profile found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            var profile = new Facade().GetProfileRepository().Get(id);
            ProfileDTO profileDTO = null;
            if (profile != null)
            {
                profileDTO = new ProfileConverter().Convert(profile);
                return Request.CreateResponse<ProfileDTO>(HttpStatusCode.OK, profileDTO);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Profile not found.")
            };
            throw new HttpResponseException(response);
        }


        /// <summary>
        /// Creates a Profile in the Database
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(ProfileDTO profileDTO)
        {
            try
            {
                var profile = new ProfileConverter().Convert(profileDTO);
                facade.GetProfileRepository().Add(profile);

                var response = Request.CreateResponse<ProfileDTO>(HttpStatusCode.Created, profileDTO);
                var uri = Url.Link("GetProfileById", new { profile.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a profile to the database")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Updates a Profile in Database
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(ProfileDTO profileDTO)
        {
            try
            {
                Profile profile = new ProfileConverter().Convert(profileDTO);
                facade.GetProfileRepository().Edit(profile);
                var response = Request.CreateResponse<ProfileDTO>(HttpStatusCode.OK, profileDTO);
                var uri = Url.Link("GetProfileById", new { profile.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching profile")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Delete a Profile in database
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
            facade.GetProfileRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}
