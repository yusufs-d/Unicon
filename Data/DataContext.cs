using Microsoft.EntityFrameworkCore;

namespace Unicon.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Entity> Entities => Set<Entity>();
        public DbSet<Comment> Comments => Set<Comment>();
        
    }
}