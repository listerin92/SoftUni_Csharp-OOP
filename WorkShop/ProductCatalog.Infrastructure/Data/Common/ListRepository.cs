using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public class ListRepository : IRepository
    {
        private List<object> dbSets = new List<object>();

        protected List<T> Dbset<T>() where T : class
        {
            object dbset = dbSets.FirstOrDefault(s => s.GetType() == typeof(List<T>));
            if (dbset == null)
            {
                dbset = new List<T>();
                dbSets.Add(dbset);
            }

            return (List<T>)dbset;
        }
        public void Add<T>(T entity) where T : class
        {
            string keyProperty = GetKeyPropertyName<T>();
            PropertyInfo pi = typeof(T).GetProperty(keyProperty);

            if (pi.PropertyType == typeof(int))
            {
                pi.SetValue(entity, Dbset<T>().Count + 1);
            }

            Dbset<T>().Add(entity);
        }
        public IQueryable<T> All<T>() where T : class
        {
            return Dbset<T>().AsQueryable();
        }
        public void Delete<T>(T entity) where T : class
        {
            Dbset<T>().Remove(entity);
        }
        public T GetById<T>(object id) where T : class
        {
            string keyProperty = GetKeyPropertyName<T>();
            T entity = null;

            if (keyProperty != null)
            {
                PropertyInfo pi = typeof(T).GetProperty(keyProperty);

                foreach (var item in Dbset<T>())
                {
                    if (pi.GetValue(item).Equals(id))
                    {
                        entity = item;
                        break;
                    }
                }
            }

            if (entity == null)
            {
                throw new KeyNotFoundException("No entity with provided id found");
            }
            return entity;
        }
        public void Delete<T>(object id) where T : class
        {
            T entity = GetById<T>(id);
            Delete(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            string keyProperty = GetKeyPropertyName<T>();
            PropertyInfo pi = typeof(T).GetProperty(keyProperty);

            T item = GetById<T>(pi.GetValue(entity));

            if (item != null)
            {
                int index = Dbset<T>().IndexOf(item);
                Dbset<T>()[index] = entity;
            }

        }
        public int SaveChanges()
        {
            return 1;
        }
        public void Dispose()
        {
            dbSets = null;
        }
        private string GetKeyPropertyName<T>() where T : class
        {
            string keyProperty = null;
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (Attribute.IsDefined(property, typeof(KeyAttribute)))
                {
                    keyProperty = property.Name;
                    break;
                }
            }

            if (keyProperty == null)
            {
                keyProperty = properties
                    .Where(p => p.Name.ToUpper() == "ID")
                    .Select(p => p.Name)
                    .FirstOrDefault();
            }

            if (keyProperty == null)
            {
                throw new MemberAccessException("No key property found");
            }

            return keyProperty;
        }
    }
}