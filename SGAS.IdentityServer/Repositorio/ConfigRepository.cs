using SGAS.IdentityServer.Entidades;
using SGAS.IdentityServer.Interfaces;
using SGAS.IdSvr.Contexto;
using SGAS.Infra.Repository;

namespace SGAS.IdentityServer.Repositorio
{
    public class ConfigRepository : BaseRepository<Config>, IConfigRepository
    {
        public ConfigRepository(IdentityContext db) : base(db)
        {
        }
    }
}
