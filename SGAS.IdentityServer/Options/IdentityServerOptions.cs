using SGAS.IdentityServer.Interfaces.Options;

namespace SGAS.IdentityServer.Options
{
    public class IdentityServerOptions : IIdentityServerOptions
    {
        private readonly IConfiguration _configuration;
        public IdentityServerOptions(IConfiguration configuration)
        {
            _configuration = configuration;

            Host = _configuration.GetSection("").Value;
            SecretKey = _configuration.GetSection("").Value;
        }

        public string Host { get; set; }

        public string SecretKey { get; set; }   




    }
}
