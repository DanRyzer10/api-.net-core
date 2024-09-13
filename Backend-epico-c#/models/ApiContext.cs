using Microsoft.EntityFrameworkCore;

namespace Backend_epico_c_.models
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {
        }

       public DbSet<Client> Clients { get; set; }
    }
}
