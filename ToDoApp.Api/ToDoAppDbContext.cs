using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Models;

namespace ToDoApp.Api
{
    public class ToDoAppDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=LENOVO_IDEAPAD\SQLEXPRESS;Initial Catalog=ToDoAppDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ToDoItem>().ToTable("ToDoItem");

            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.Property(m => m.IsDeleted).HasConversion(v => v.ToString(), v => bool.Parse(v));
            });
        }
    }
}
