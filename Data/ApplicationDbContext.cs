using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Seed database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoTask>().HasData(
                new ToDoTask { Id = 1, Content = "Do laundry" },    
                new ToDoTask { Id = 2, Content = "Eat dinner" },    
                new ToDoTask { Id = 3, Content = "Go to work" }    
            );
        }
    }
}
