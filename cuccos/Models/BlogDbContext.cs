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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=blogger;user=root;password=;SslMode=None");
        }
    }
}
