using SGAS.IdentityServer.Interfaces;
using SGAS.IdentityServer.Interfaces.Util;
using SGAS.IdentityServer.Repositorio;
using SGAS.IdentityServer.Util;
using SGAS.Infra.Repository;

namespace SGAS.IdentityServer.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDepencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }

    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<IFuncaoUsuarioRepository, FuncaoUsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IConfigRepository, ConfigRepository>();
            services.AddScoped<IComputeHash, ComputeHash>();
        }
           
    }
}
