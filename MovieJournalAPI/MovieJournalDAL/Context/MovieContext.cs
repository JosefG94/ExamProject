using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieJournalDAL.Model;

namespace MovieJournalDAL.Context
{
    public class MovieContext : DbContext
    {

        public MovieContext() : base("MovieJournal")
        {
            Database.SetInitializer(new MovieDBInitialize());

            //Add this line to make json conversin happy.
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Can only be used when you have List<> of objects
            //modelBuilder.Entity<Movie>().HasMany(g => g.Genres).WithMany();
        }
        //OnModelCreating States exactly which lists the tables are connected as many-to-many through
        public DbSet<Movie> Movies { get; set; }
       



    }
}
