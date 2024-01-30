using Microsoft.EntityFrameworkCore;
using Sample_BackEnd.Models.Domain;
namespace Sample_BackEnd.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<TaskList> TaskList { get; set; }
    }
}
