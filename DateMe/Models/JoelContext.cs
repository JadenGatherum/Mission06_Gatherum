using Microsoft.EntityFrameworkCore;
using Mission06_Gatherum.Models;

namespace Mission06_Gatherum.Models
{
    public class JoelContext : DbContext
    {
        public JoelContext(DbContextOptions<JoelContext> options): base (options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
