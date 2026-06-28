
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using University.Data.Context;
namespace University.Data.Modules
{
    public class DataModule : Module
    {

        private readonly IConfiguration _configuration;

        public DataModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
         


        protected override void Load(ContainerBuilder builder)
        {

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return new AppDbContext(optionsBuilder.Options);
            })
            .AsSelf()
            .InstancePerLifetimeScope();

         
        }
    }
}
