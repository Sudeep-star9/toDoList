using Microsoft.EntityFrameworkCore;
using toDoList.Enums;
using toDoList.Model;

namespace toDoList.Context
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1, Name = "Work" },
                new Category {Id=2, Name = "Personal" }
            );

            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem
                {
                    Id = 1,
                    Title = "Finish project report",
                    Description = "Complete the report by Friday",
                    IsCompleted = false,
                    Importance = ImportanceLevel.Medium,
                    DueDate = DateTime.UtcNow.AddDays(3),
                    CategoryId = 1
                },
                new ToDoItem
                {
                    Id = 2,
                    Title = "Futsal",
                    Description = "With xyz boys ",
                    IsCompleted = false,
                    Importance = ImportanceLevel.Medium,
                    DueDate = DateTime.UtcNow.AddDays(1),
                    CategoryId = 2
                }
            );
        }
    }
}
