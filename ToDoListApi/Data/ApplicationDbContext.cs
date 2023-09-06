using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var todos = new List<ToDoItem>
            {
                new ToDoItem { Title = "Morning exercise", Done = false, Id = 1 },
                new ToDoItem { Title = "Read for 30 minutes", Done = false, Id = 2 },
                new ToDoItem { Title = "Work on project tasks", Done = false, Id = 3 },
                new ToDoItem { Title = "Lunch break", Done = false, Id = 4 },
                new ToDoItem { Title = "Attend team meeting", Done = true, Id = 5 },
                new ToDoItem { Title = "Complete work tasks", Done = true, Id = 6 },
                new ToDoItem { Title = "Dinner", Done = true, Id = 7 },
                new ToDoItem { Title = "Relax and unwind", Done = true, Id = 8 },
            };

            modelBuilder.Entity<ToDoItem>().HasData(todos);
        }
    }
}
