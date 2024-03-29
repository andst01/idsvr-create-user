using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGAS.IdentityServer.Configuration;
using SGAS.IdSvr.Contexto;
using SGAS.IdSvr.Entidade;
using System.Data;
using System.Globalization;
using System.IO.Compression;

namespace SGAS.IdentityServer
{
    public class Startup
    {
        // public IConfiguration _configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration, 
                       IWebHostEnvironment environment)
        {
            _configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // DI
            services.AddDepencyInjectionConfiguration();
            // Identity Server
            services.AddIdentityServerConfiguration();
            // AutoMapper
            services.AddAutoMapperConfiguration();
            // Banco de Dados
            services.AddDataContextConfiguration(_configuration);
            // Identity User e Role
            services.AddUserIdentityConfiguration();
            // Configurações comuns
            services.AddCommonConfiguration();

            //services.AddIdentityServer()
            // .AddDeveloperSigningCredential()

            // .AddInMemoryIdentityResources(Config.IdentityResources)
            // //.AddInMemoryApiResources(Config.Api())
            // .AddInMemoryApiScopes(Config.ApiScopes)
            // .AddInMemoryClients(Config.Clients);

            //services.Configure<RequestLocalizationOptions>(
            //               opt =>
            //               {
            //                   var cultures = new List<CultureInfo>()
            //                   {
            //            new CultureInfo("en-US"),
            //            new CultureInfo("pt-BR")
            //                   };

            //                   opt.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
            //                   opt.SupportedCultures = cultures;
            //                   opt.SupportedUICultures = cultures;
            //               });
            //services.AddResponseCompression(options =>
            //{
            //    options.Providers.Add<GzipCompressionProvider>();
            //    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            //});


            //services.Configure<GzipCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Fastest;
            //});

            //var key = Encoding.ASCII.GetBytes("super secret key");
           // services.AddDbContext<IdentityContext>(x => x.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString")));

            #region Configuração anterior antes de bater cabeça com AddEntityFrameworkStores

            //services.AddTransient<IRoleStore<Funcao>, CustomRoleStore>();

            // services.AddTransient<IdentityUser<int>, Usuario>();

            //services.AddIdentity<Usuario, Funcao>()
            //    .AddRoles<Funcao>()
            //    .AddSignInManager<SignInManager<Usuario>>()
            //    .AddUserManager<UserManager<Usuario>>()
            //    .AddDefaultTokenProviders()
            //    .AddEntityFrameworkStores<IdentityContext>(); ;

            //services.AddIdentityCore<Usuario>(o =>
            //  {
            //      o.User.RequireUniqueEmail = false;
            //  })

            //     .AddRoles<Funcao>()
            //     .AddRoleValidator<RoleValidator<Funcao>>()
            //     .AddRoleManager<RoleManager<Funcao>>()
            //     .AddSignInManager<SignInManager<Usuario>>();
            ////.AddUserManager<UserManager<Usuario>>();

            #endregion

            //IdentityBuilder builder = services.AddIdentityCore<Usuario>(opt =>
            //{
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequiredLength = 4;
            //    opt.Password.RequireNonAlphanumeric = false;
            //    opt.Password.RequireUppercase = false;
            //    opt.Lockout.MaxFailedAccessAttempts = 3;

            //});


            //services.AddAutoMapper(typeof(AutoMapperProfiles));

            //builder = new IdentityBuilder(builder.UserType, typeof(Funcao), builder.Services);
            //builder.AddEntityFrameworkStores<IdentityContext>(); // essa linha estava no lugar errado
            //builder.AddRoleValidator<RoleValidator<Funcao>>();
            //builder.AddRoleManager<RoleManager<Funcao>>();
            //builder.AddSignInManager<SignInManager<Usuario>>();
            //builder.AddUserManager<UserManager<Usuario>>();
            //builder.AddDefaultTokenProviders();




            //services.AddAutoMapper(typeof(AutoMapperProfiles));

            //IdentityBuilder builder = services.AddIdentityCore<Usuario>(opt =>
            //{
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequiredLength = 4;
            //    opt.Password.RequireNonAlphanumeric = false;
            //    opt.User.RequireUniqueEmail = false;
            //    opt.Password.RequireUppercase = false;
            //    opt.Lockout.MaxFailedAccessAttempts = 3;

            //});
            //builder = new IdentityBuilder(builder.UserType, typeof(Funcao), builder.Services);
            //builder.AddEntityFrameworkStores<IdentityContext>();
            //builder.AddDefaultTokenProviders();
            //builder.AddRoleValidator<RoleValidator<Funcao>>();
            //builder.AddRoleManager<RoleManager<Funcao>>();
            //builder.AddSignInManager<SignInManager<Usuario>>();
            //builder.AddUserManager<UserManager<Usuario>>();

            // builder.bui
            // services.AddDefaultIdentity<IdentityUser>()



            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddTransient<IProfileService, ProfileService>();

            //services.AddCors();
            //services.AddCors(options =>
            //{

            //    options.AddPolicy("AllowAll",
            //        builderCors => builderCors.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AutomaticAuthentication = false;
            //});
            //services.Configure<IISOptions>(o =>
            //{
            //    o.ForwardClientCertificate = false;
            //});

            //services.AddMvc();
            //services.AddControllers();
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add MVC
            //app.UseStaticFiles();
            //app.UseRouting();

            //app.UseIdentityServer();

            // uncomment, if you want to add MVC
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});

            // app.MapControllers().AddRazorRuntimeCompilation();
            // app.UseMvc();
            app.UseAuthentication();
           // app.UseCors("AllowAll");
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
