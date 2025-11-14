using Microsoft.EntityFrameworkCore;

namespace cuccos.Models
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext()
        {

        }

        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blogger> Bloggers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=blog;user=root;password=");
        }
    }
}
