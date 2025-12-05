using Microsoft.EntityFrameworkCore;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }

        public DbSet<MyUser> users { get; set; }
        public DbSet<Cetegory> cetegories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<SubCetegory> subCetegories { get; set; }
        public DbSet<Images> images { get; set; }
    }
}
