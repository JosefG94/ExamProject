using System.Collections.Generic;
using System.Linq;
using MovieJournalDAL.Model;
using MovieJournalAPI.Models;
using System.Web.Http;

namespace MovieJournalAPI.Repository
{
    public class ProfileRepository : IRepository<Profile>
    {
        public IEnumerable<Profile> ReadAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Profiles.ToList();
            }
        }
        
        public Profile Get(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var profile = ctx.Profiles.Where(x => x.UserName == userName).FirstOrDefault();
                if (profile == null)
                    return null;
                return profile;
            }
        }

        public Profile Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Profiles.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(Profile profile)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(profile);
                ctx.SaveChanges();
            }
        }
        public void Edit(Profile profile)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Profile m = ctx.Profiles.Where(x => x.Id == profile.Id).First();
                m.Id = profile.Id;
                m.Name = profile.Name;
                m.MovieOnList = profile.MovieOnList;
                ctx.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Profile m = ctx.Profiles.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Profiles.Remove(m);
                ctx.SaveChanges();
            }
        }
    }
}