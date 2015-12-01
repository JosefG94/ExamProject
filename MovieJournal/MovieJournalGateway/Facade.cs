using MovieJournalGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalGateway
{
    public class Facade
    {
        //  private MovieOnListGateWayService GetMovieOnListGateway;

        public MovieOnListGateWayService GetMovieOnListRepository()
        {
            return new MovieOnListGateWayService();

        }

      //   private ProfileGateWayService GetProfileGateway;

        public ProfileGateWayService GetProfileGateWayService()
        {
            return new ProfileGateWayService();

        }
    }
}
