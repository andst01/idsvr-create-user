using SGAS.IdentityServer.Interfaces;
using SGAS.IdentityServer.Interfaces.Util;
using SGAS.IdSvr.Contexto;
using SGAS.IdSvr.Entidade;
using SGAS.Infra.Repository;
using System.Security.Cryptography.X509Certificates;

namespace SGAS.IdentityServer.Repositorio
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly IComputeHash _hash;
        public UsuarioRepository(IdentityContext db, IComputeHash hash) : base(db)
        {
            _hash = hash;
        }

        public Usuario ObterLoginUsuario(string username, string password)
        {
            string passwordHash = _hash.CreatePasswordHash(password);
            return  this.ObterPorParametros(x => x.UserName == username && 
                                                 x.PasswordHash == passwordHash);
        }
    }
}
