using Microsoft.EntityFrameworkCore;
using TestASP2.Models;

namespace TestASP2.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){ }
        public DbSet<Student> Students { get; set; }
    }
    
}
