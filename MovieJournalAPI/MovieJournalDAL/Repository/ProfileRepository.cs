using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieJournalDAL.Context;
using MovieJournalDAL.Model;

namespace MovieJournalDAL.Repository
{
    public class ProfileRepository : IRepository<Profile>
    {
        public IList<Profile> ReadAll()
        {
            using (var ctx = new MovieContext())
            {
                return ctx.Profiles.Include("Title").ToList();
            }
        }
        public Profile Get(int id)
        {
            using (var ctx = new MovieContext())
            {
                return ctx.Profiles.Include("Title").FirstOrDefault();
            }
        }
        public void Add(Profile movie)
        {
            using (var ctx = new MovieContext())
            {
                ctx.Profiles.Add(movie);
                ctx.SaveChanges();
            }
        }
        public void Edit(Profile movie)
        {
            using (var ctx = new MovieContext())
            {
                Profile m = ctx.Profiles.Where(x => x.Id == movie.Id).First(); 
                //insert something here
               
              
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieContext())
            {
                Profile m = ctx.Profiles.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Profiles.Remove(m);
                ctx.SaveChanges();
            }
        }
    }
}


