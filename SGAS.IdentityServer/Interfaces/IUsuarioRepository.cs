using SGAS.IdSvr.Entidade;

namespace SGAS.IdentityServer.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario ObterLoginUsuario(string username, string password);
    }
}
