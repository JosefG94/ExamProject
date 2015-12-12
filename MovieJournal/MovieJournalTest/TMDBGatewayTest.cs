using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieJournalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDBGateway.TMDBServices;

namespace MovieJournalTest
{
    [TestClass]
    class TMDBGatewayTest
    {
        TMDBGateWayService tmdbGW = TMDBGateWayService.Instance;
        [TestMethod]
        private void GetPopular_Returns_List_Of_Movies_Test()
        {
            MovieList movielist = tmdbGW.GetPopular();
          //  Assert.IsTrue(movielist.,1);
        }
    }
}
