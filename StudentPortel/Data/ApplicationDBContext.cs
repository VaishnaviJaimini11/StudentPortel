using Microsoft.EntityFrameworkCore;
using StudentPortel.Models.Entity;

namespace StudentPortel.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {      
        }

        public  DbSet<Student> Students { get; set; }
    }
}
