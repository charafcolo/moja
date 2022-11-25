using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAO
{
    public class DefaultDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                                .SetBasePath(path)
                                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new ();
            optionBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
