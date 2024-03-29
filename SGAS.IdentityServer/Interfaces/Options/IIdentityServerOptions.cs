namespace SGAS.IdentityServer.Interfaces.Options
{
    public interface IIdentityServerOptions
    {
        string Host { get; set; }

        string SecretKey { get; set; }
    }
}
