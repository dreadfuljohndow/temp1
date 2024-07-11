using Md.LocalStorage.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace Md.LocalStorage.EfCoreMsSqlProvider
{
    internal sealed class DbDataContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;

        // TODO DL: ef core migration cannot create instance without default constructor = need to figure out a way how to fix that
        public DbDataContext(string connectionString= "Server=(local);Database=MonkeyDoApp_dev;User Id=admin;Password=admin;Trust Server Certificate=true")
        {
            _connectionString = connectionString;
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: _connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
