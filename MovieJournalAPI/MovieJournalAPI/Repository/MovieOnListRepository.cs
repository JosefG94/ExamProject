using MovieJournalDAL.Model;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieJournalAPI.Models;

namespace MovieJournalDAL.Repository
{
   public class MovieOnListRepository
    {
        public IEnumerable<MovieOnList> ReadAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.MoviesOnList.Include(x => x.Profile).ToList();
            }
        }
        public MovieOnList Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.MoviesOnList.Include(x => x.Profile).Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(MovieOnList movieOnList)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MoviesOnList.Add(movieOnList);
                ctx.SaveChanges();
            }
        }
        public void Edit(MovieOnList movieOnList)
        {
            using (var ctx = new ApplicationDbContext())
            {
                MovieOnList m = ctx.MoviesOnList.Where(x => x.Id == movieOnList.Id).First();
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
            using (var ctx = new ApplicationDbContext())
            {
                MovieOnList m = ctx.MoviesOnList.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.MoviesOnList.Remove(m);
                ctx.SaveChanges();
            }
        }

    }
}


