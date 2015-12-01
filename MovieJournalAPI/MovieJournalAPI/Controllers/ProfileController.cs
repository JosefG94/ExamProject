using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieJournalDAL.Repository;
using MovieJournalDAL;
using MovieJournalDAL.Model;
using MovieJournalDTO.Converter;
using MovieJournalDTO.ModelDTO;

namespace MovieJournalAPI.Controllers
{
    public class ProfileController : ApiController
    {
        Facade facade = new Facade();
        
        public IEnumerable<ProfileDTO> GetAll()
        {
            var profile = facade.GetProfileRepository().ReadAll();
            return new ProfileConverter().Convert(profile);
        }

    }
}
