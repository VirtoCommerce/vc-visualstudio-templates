using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.Data.Repositories
{
    public class $ext_supersafename$DbContext : DbContextWithTriggers
    {
        public $ext_supersafename$DbContext(DbContextOptions<$ext_supersafename$DbContext> options)
          : base(options)
        {
        }

        protected $ext_supersafename$DbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<MyModuleEntity>().ToTable("MyModule").HasKey(x => x.Id);
            // modelBuilder.Entity<MyModuleEntity>().Property(x => x.Id).HasMaxLength(128);
            // base.OnModelCreating(modelBuilder);
        }
    }
}

