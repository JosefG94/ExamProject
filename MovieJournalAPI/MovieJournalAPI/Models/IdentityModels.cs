using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MovieJournalDAL.Model;
using System.Data.Entity;
using System.Linq;

namespace MovieJournalAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual Profile Profile { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MovieJournalDB", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MovieJournalDBInitialize());
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<MovieOnList> MoviesOnList { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class MovieJournalDBInitialize : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // If there are any users in the database, the seed should do nothing
            if (!context.Users.Any())
            {
                // Creates references for the built-in authentication classes
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                // Creates "Admin" and "User" as roles
                var AdminRole = new IdentityRole("Admin");
                var UserRole = new IdentityRole("User");
                roleManager.Create(AdminRole);
                roleManager.Create(UserRole);

                // Creates the profile of the admin before creating logon
                Profile AdminProfile = new Profile() { Name = "Josef Gharib", UserName = "AdminUser" };

                // Creates the Admin with a User name of "AdminUser" and password of "pass123"
                var CreateAdminUser = new ApplicationUser() { UserName = AdminProfile.UserName, Profile = AdminProfile };
                userManager.Create(CreateAdminUser, "pass123");

                userManager.SetLockoutEnabled(CreateAdminUser.Id, false);
                userManager.AddToRole(CreateAdminUser.Id, "Admin");

                // Creates movies to the Admin user
                context.MoviesOnList.Add(new MovieOnList() { Id = 1, MovieId = 140607, Rating = 5, Review = "Awsome", Watched = true, Profile = AdminProfile});
                context.MoviesOnList.Add(new MovieOnList() { Id = 2, MovieId = 102899, Rating = 0, Review = "", Watched = false, Profile = AdminProfile});
                context.MoviesOnList.Add(new MovieOnList() { Id = 3, MovieId = 87101, Rating = 4, Review = "Good", Watched = true, Profile = AdminProfile});


                base.Seed(context);
            }
        }
    }
}