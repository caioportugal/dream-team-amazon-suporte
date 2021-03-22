using Microsoft.EntityFrameworkCore;

namespace Amazon.Suporte.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
    }
}
