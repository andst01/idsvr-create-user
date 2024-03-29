using SGAS.IdentityServer.Interfaces;
using SGAS.IdSvr.Contexto;
using SGAS.IdSvr.Entidade;
using SGAS.Infra.Repository;

namespace SGAS.IdentityServer.Repositorio
{
    public class FuncaoUsuarioRepository : BaseRepository<FuncaoUsuario>, IFuncaoUsuarioRepository
    {
        public FuncaoUsuarioRepository(IdentityContext db) : base(db)
        {
        }
    }
}
