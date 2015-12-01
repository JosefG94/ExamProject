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
            Profile p1 = context.Profiles.Add(new Profile() { Id = 2, Name = "Abdirahman Yusuf", });
            Profile p2 = context.Profiles.Add(new Profile() { Id = 3, Name = "Pote Lolle" });
            Profile p3 = context.Profiles.Add(new Profile() { Id = 4, Name = "Obiwan Kenobi" });
            Profile p4 = context.Profiles.Add(new Profile() { Id = 1, Name = "Josef Gharib", });



            context.MoviesOnList.Add(new MovieOnList() { Id = 1, Rating = 5, Review = "Awsome", Watched = true, Profile = p1 });
            context.MoviesOnList.Add(new MovieOnList() { Id = 2, Rating = 3, Review = "Shiit", Watched = false, Profile = p2 });
            context.MoviesOnList.Add(new MovieOnList() { Id = 3, Rating = 4, Review = "Good", Watched = true, Profile = p3 });
           

            base.Seed(context);
        }

    }
}
