using Microsoft.EntityFrameworkCore;

namespace cuccos.Models
{
    public class BlogDbContext: DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=blogger;user=root;password=;SslMode=None");
        }
    }
}
