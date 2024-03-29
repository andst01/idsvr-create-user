namespace SGAS.IdentityServer.Configuration
{
    public static class IdentityServerConfiguration
    {
        public static void AddIdentityServerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddIdentityServer()
             .AddDeveloperSigningCredential()

             .AddInMemoryIdentityResources(Config.IdentityResources)
             //.AddInMemoryApiResources(Config.Api())
             .AddInMemoryApiScopes(Config.ApiScopes)
             .AddInMemoryClients(Config.Clients);
        }
    }
}
