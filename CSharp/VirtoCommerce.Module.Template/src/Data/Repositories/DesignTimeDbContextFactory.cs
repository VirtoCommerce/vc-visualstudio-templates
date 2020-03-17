using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace $ext_safeprojectname$.Data.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<$ext_safeprojectname$DbContext>
    {
        public $ext_safeprojectname$DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<$ext_safeprojectname$DbContext>();

            builder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=virto;Password=virto;MultipleActiveResultSets=True;Connect Timeout=30");

            return new $ext_safeprojectname$3DbContext(builder.Options);
        }
    }
}
