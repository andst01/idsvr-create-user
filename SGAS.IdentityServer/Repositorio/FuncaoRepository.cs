
using SGAS.IdentityServer.Interfaces;
using SGAS.IdSvr.Contexto;
using SGAS.IdSvr.Entidade;

namespace SGAS.Infra.Repository
{
    public class FuncaoRepository : BaseRepository<Funcao>, IFuncaoRepository
    {
        private readonly IdentityContext _db;

        public FuncaoRepository(IdentityContext db) : base(db)
        {
            _db = db;
        }
    }
}
