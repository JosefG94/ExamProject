using MovieJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalAPI.Repository
{
    public class Facade
    {
        private MovieOnListRepository movieOnListRepo;

        public MovieOnListRepository GetMovieOnListRepository()
        {
            if (movieOnListRepo == null)
            {
                movieOnListRepo = new MovieOnListRepository();
            }
            return movieOnListRepo;
        }

        private ProfileRepository profileRepo;


        public ProfileRepository GetProfileRepository()
        {
            if (profileRepo == null)
            {
                profileRepo = new ProfileRepository();
            }
            return profileRepo;
        }
    }
}
