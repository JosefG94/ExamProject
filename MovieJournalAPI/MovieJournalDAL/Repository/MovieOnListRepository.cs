using MovieJournalDAL.Context;
using MovieJournalDAL.Model;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDAL.Repository
{
   public class MovieOnListRepository
    {
        public IEnumerable<movieOnList> ReadAll()
        {
            using (var ctx = new MovieContext())
            {
                return ctx.MoviesOnList.Include(x => x.Profile).ToList();
            }
        }
        public movieOnList Get(int id)
        {
            using (var ctx = new MovieContext())
            {
                return ctx.MoviesOnList.Include(x => x.Profile).Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(movieOnList movieOnList)
        {
            using (var ctx = new MovieContext())
            {
                ctx.MoviesOnList.Add(movieOnList);
                ctx.SaveChanges();
            }
        }
        public void Edit(movieOnList movieOnList)
        {
            using (var ctx = new MovieContext())
            {
                movieOnList m = ctx.MoviesOnList.Where(x => x.Id == movieOnList.Id).First();
                m.Id = movieOnList.Id;
                m.Rating = movieOnList.Rating;
                m.Review = movieOnList.Review;
                m.Watched = movieOnList.Watched;
                m.Profile = movieOnList.Profile;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieContext())
            {
                movieOnList m = ctx.MoviesOnList.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.MoviesOnList.Remove(m);
                ctx.SaveChanges();
            }
        }

    }
}


