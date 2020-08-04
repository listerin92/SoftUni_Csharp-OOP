using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {

        protected DbContext Context { get; set; }

        public Repository(ApplicationDBContext context)
        {
            this.Context = context;
        }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }
        public T GetById<T>(object id) where T : class
        {
            return DbSet<T>().Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(object id) where T : class
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
