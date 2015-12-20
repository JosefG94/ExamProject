using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieJournalBLL;
using MovieJournalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalTest
{
    [TestClass]
    public class MovieOnListTest
    {
        MovieOnListBLL movbll = MovieOnListBLL.Instance;

        [TestMethod]
        public void Change_Watched_To_Opposite_test()
        {
            var movfalsetotrue = new MovieOnList() { Id = 1, MovieId = 5, Watched=false };
            var movtruetofalse = new MovieOnList() { Id = 2, MovieId = 10, Watched = true };
            movbll.ChangeWatched(movfalsetotrue);
            movbll.ChangeWatched(movtruetofalse);

            Assert.AreEqual(movfalsetotrue.Watched, true);
            Assert.AreEqual(movtruetofalse.Watched, false);
        }

        [TestMethod]
        public void Change_Review_test()
        {
            string reviewtoedit = "This review should be edited";
            string edittothis = "This is the new review";

            var mov = new MovieOnList() { Id = 1, MovieId = 5, Review = reviewtoedit };

            movbll.ChangeReview(mov,edittothis);
            Assert.AreEqual(mov.Review, edittothis);
        }

        [TestMethod]
        public void Change_Rating_Test()
        {
            int ratingtoedit = 4;
            int edittothis = 9;

            var mov = new MovieOnList() { Id = 1, MovieId = 5, Rating = ratingtoedit};

            movbll.ChangeRating(mov, edittothis);
            Assert.AreEqual(mov.Rating, edittothis);
        }
    }
}
