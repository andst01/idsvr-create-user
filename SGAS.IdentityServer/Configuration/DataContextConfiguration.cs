using Microsoft.EntityFrameworkCore;
using SGAS.IdSvr.Contexto;

namespace SGAS.IdentityServer.Configuration
{
    public static class DataContextConfiguration
    {
        public static void AddDataContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<IdentityContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

        }
    }
}
