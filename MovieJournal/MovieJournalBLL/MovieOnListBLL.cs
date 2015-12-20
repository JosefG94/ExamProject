using MovieJournalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalBLL
{
    public class MovieOnListBLL
    {

        private static MovieOnListBLL instance;

        private MovieOnListBLL() { }

        public static MovieOnListBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovieOnListBLL();
                }
                return instance;
            }
        }

        public MovieOnList ChangeWatched(MovieOnList mov)
        {
            mov.Watched = !mov.Watched;
            return mov;
        }

        public MovieOnList ChangeReview(MovieOnList mov, string newreview)
        {
            mov.Review = newreview;
            return mov;
        }

        public MovieOnList ChangeRating(MovieOnList mov, int newrating)
        {
            mov.Rating = newrating;
            return mov;
        }
    }

    
}
