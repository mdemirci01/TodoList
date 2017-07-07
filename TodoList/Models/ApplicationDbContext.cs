using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TodoList.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, TodoList.Migrations.Configuration>("DefaultConnection"));
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}