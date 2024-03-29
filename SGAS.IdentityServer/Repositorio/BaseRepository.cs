using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using SGAS.IdentityServer.Interfaces;
using SGAS.IdSvr.Contexto;

namespace SGAS.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IdentityContext _db;
        private bool _disposed = false;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public BaseRepository(IdentityContext db)
        {
            _db = db;
        }

       //  public IUnitOfWork unitOfWork => throw new NotImplementedException();

        public T Adicionar(T entity)
        {
           
            var retorno = _db.Set<T>().Add(entity);
            var entity1 = retorno.Entity;
            return retorno.Entity;
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            var retorno = await _db.Set<T>().AddAsync(entity);
            return retorno.Entity;
        }

        public T Atualizar(T entity)
        {            
            _db.Entry<T>(entity).State = EntityState.Modified;
            var retorno = _db.Set<T>().Attach(entity);
            return retorno.Entity;
        }

        public async Task<bool> Commit()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        //public async Task<bool?> PublishEvent()
        //{
        //    return await _db.PublishEvent();
        //}

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Excluir(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public T ObterPorId(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public IQueryable<T> ObterTodos()
        {
            return _db.Set<T>();
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }

        public T ObterPorParametros(Expression<Func<T, bool>> predicate)
        {
           return _db.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T Atualizar(Expression<Func<T, bool>> predicate, T novosValores)
        {
            var entidade = _db.Set<T>().Where(predicate).FirstOrDefault();
            _db.Entry<T>(entidade).CurrentValues.SetValues(novosValores);
            _db.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public IEnumerable<T> ListarPorParametros(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }
    }
}
