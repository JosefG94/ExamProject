using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieJournalDAL.Context;
using MovieJournalDAL.Model;

namespace MovieJournalDAL.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        public IList<Movie> ReadAll()
        {
            using (var ctx = new MovieContext())
            {
                return ctx.Movies.Include("Title").ToList();
            }
        }
        public Movie Get(int id)
        {
            using (var ctx = new MovieContext())
            {
                return ctx.Movies.Include("Title").FirstOrDefault();
            }
        }
        public void Add(Movie movie)
        {
            using (var ctx = new MovieContext())
            {
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
            }
        }
        public void Edit(Movie movie)
        {
            using (var ctx = new MovieContext())
            {
                Movie m = ctx.Movies.Where(x => x.Id == movie.Id).First();
                m.Title = movie.Title;
               
              
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieContext())
            {
                Movie m = ctx.Movies.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Movies.Remove(m);
                ctx.SaveChanges();
            }
        }

    }
}


