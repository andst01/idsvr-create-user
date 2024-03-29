using Microsoft.AspNetCore.Identity;
using SGAS.IdSvr.Contexto;
using SGAS.IdSvr.Entidade;

namespace SGAS.IdentityServer.Configuration
{
    public static class UserIdentityConfiguration
    {
        public static void AddUserIdentityConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Configuração anterior antes de bater cabeça com AddEntityFrameworkStores

            IdentityBuilder builder = services.AddIdentityCore<Usuario>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.MaxFailedAccessAttempts = 3;

            });

            builder = new IdentityBuilder(builder.UserType, typeof(Funcao), builder.Services);
            builder.AddEntityFrameworkStores<IdentityContext>(); // essa linha estava no lugar errado
            builder.AddRoleValidator<RoleValidator<Funcao>>();
            builder.AddRoleManager<RoleManager<Funcao>>();
            builder.AddSignInManager<SignInManager<Usuario>>();
            builder.AddUserManager<UserManager<Usuario>>();
            builder.AddDefaultTokenProviders();



        }
    }
}
