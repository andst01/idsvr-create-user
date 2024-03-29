using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGAS.IdentityServer.Entidades;
using SGAS.IdentityServer.Mappings;
using SGAS.IdSvr.Entidade;
using SGAS.Infra.Mappings;
using System.IO;

namespace SGAS.IdSvr.Contexto
{
    // : IdentityDbContext<Usuario, Funcao, int>
    public class IdentityContext : IdentityDbContext<Usuario, Funcao, int, IdentityUserClaim<int>,
                FuncaoUsuario, IdentityUserLogin<int>,
                IdentityRoleClaim<int>, IdentityUserToken<int>>   
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        //: IdentityDbContext<Usuario, Funcao, int>

        //public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        //{
        //}

        //: IdentityDbContext<Usuario, Funcao, int, IdentityUserClaim<int>,
        //        FuncaoUsuario, IdentityUserLogin<int>,
        //        IdentityRoleClaim<int>, IdentityUserToken<int>>

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .AddJsonFile("appsettings.Development.json")
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        //    optionsBuilder
        //        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        //        //.UseLazyLoadingProxies()
        //        .UseSqlServer(connectionString);
        //}

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Funcao> Funcao { get;set; }

        public DbSet<FuncaoUsuario> FuncaoUsuario { get; set; }

        public DbSet<Config> Config { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new FuncaoMap());
            modelBuilder.ApplyConfiguration(new FuncaoUsuarioMap());
            modelBuilder.ApplyConfiguration(new ConfigMap());

        }


    }
}
