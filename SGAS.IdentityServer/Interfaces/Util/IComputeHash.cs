namespace SGAS.IdentityServer.Interfaces.Util
{
    public interface IComputeHash
    {
        string CreatePasswordHash(string password);
    }
}
