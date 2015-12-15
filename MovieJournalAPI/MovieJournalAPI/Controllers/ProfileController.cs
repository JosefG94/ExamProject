using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieJournalDAL.Model;
using MovieJournalDTO.Converter;
using MovieJournalDTO.ModelDTO;
using MovieJournalAPI.Repository;

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
            return new ProfileDTOConverter().Convert(profile);
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
                profileDTO = new ProfileDTOConverter().Convert(profile);
                return Request.CreateResponse<Profile>(HttpStatusCode.OK, profile);
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
        public HttpResponseMessage Post(Profile profile)
        {
            try
            {
                var profileDTO = new ProfileDTOConverter().Convert(profile);
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
        public HttpResponseMessage Put(Profile profile)
        {
            try
            {
                var profileDTO = new ProfileDTOConverter().Convert(profile);
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
