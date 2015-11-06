using MovieJournalDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieJournalDAL.Context
{
    public class MovieDBInitialize : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            Profile profile2 = context.Profiles.Add(new Profile() { Id = 2, Name = "Abdirahman Yusuf" });
            Profile profile3 = context.Profiles.Add(new Profile() { Id = 3, Name = "Pote Lolle" });
            Profile profile4 = context.Profiles.Add(new Profile() { Id = 4, Name = "Obiwan Kenobi" });
            var followers = new List<Profile> { profile2,profile3};
            Profile profile1 = context.Profiles.Add(new Profile() { Id = 1, Name = "Josef Gharib", Profiles = followers });

            base.Seed(context);
        }

    }
}
