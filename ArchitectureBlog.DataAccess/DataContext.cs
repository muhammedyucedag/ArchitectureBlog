using ArchitectureBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBlog.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("User ID =postgres;Password=1q2w3e4R;Server=localhost;Port=5432;Database=ArchitectureBlog;Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
