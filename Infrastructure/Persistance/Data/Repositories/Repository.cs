using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techpork.Core.Extensions;
using Techpork.Core.Repositories.Base;
using Techpork.Core.RepositoryParams;

namespace Techpork.Infrastructure.Persistance.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ILogger<Repository<T>> _logger;
        private readonly TechPorkContext _context;
        private DbSet<T> _entities;

        public Repository(TechPorkContext connContext, ILogger<Repository<T>> logger)
        {
            _context = connContext;
            _entities = _context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
               .ToListAsync();
        }

        public virtual IQueryable<T> GetAllQuery()
        {
            return _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllByPropertyAsync(GetByPropertyParams parameters)
        {
            return await GetByPropertyQuery(parameters)
                .ToListAsync();
        }

        public virtual async Task<List<T>> GetAllByPropertyAsync(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes)
        {
            return await GetAllByPropertyAsync(new GetByPropertyParams(property, searchItem, noTracking, includes));
        }

        public virtual async Task<T> GetByPropertyAsync(GetByPropertyParams parameters)
        {
            return await GetByPropertyQuery(parameters)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByPropertyAsync(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes)
        {
            return await GetByPropertyAsync(new GetByPropertyParams(property, searchItem, noTracking, includes));
        }

        public virtual List<T> GetAllByProperty(GetByPropertyParams parameters)
        {
            return GetByPropertyQuery(parameters)
                .ToList();
        }

        public virtual List<T> GetAllByProperty(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes)
        {
            return GetAllByProperty(new GetByPropertyParams(property, searchItem, noTracking, includes));
        }

        public virtual T GetByProperty(GetByPropertyParams parameters)
        {
            return GetByPropertyQuery(parameters)
                .FirstOrDefault();
        }

        public virtual T GetByProperty(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes)
        {
            return GetByProperty(new GetByPropertyParams(property, searchItem, noTracking, includes));
        }

        public virtual IQueryable<T> SearchByProperty(string filter, string property)
        {
            if (string.IsNullOrEmpty(property)) throw new ArgumentNullException();
            var idName = _context.Model.FindEntityType(typeof(T))
                .FindProperty(property)?.Name;
            if (idName == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(filter))
                return _entities;
            return _entities
                .Where(x => EF.Property<string>(x, idName).Contains(filter));
            //.Where(x => EF.Property<string>(x, idName) == filter);
        }

        public virtual IQueryable<T> SearchByProperties(string filter, params string[] properties)
        {
            if (properties == null || properties?.Length == 0) throw new ArgumentNullException();
            var model = _context.Model.FindEntityType(typeof(T));
            string tableName = model?.GetTableName();
            var idName = model?.FindProperties(properties)?.AsQueryable();
            if (idName == null) throw new ArgumentNullException();
            var filterSearch = (string.IsNullOrEmpty(filter)) ? string.Empty : "%" + filter.ToLower() + "%";
            var names = idName.Select(n => n.Name.ToSnakeCase()).ToArray();
            string query = string.Format("SELECT * FROM public." + tableName +
                ((properties.Length > 0
                && !string.IsNullOrEmpty(filter)) ? " WHERE {0} {1}" : string.Empty),
                ((names.Length > 0
                && properties.Length > 0
                && !string.IsNullOrEmpty(filter)) ? string.Join(" ILIKE {0}" + " OR ", names) : string.Empty),
                (names.Length > 0
                && properties.Length > 0
                && !string.IsNullOrEmpty(filter)) ? " ILIKE {0}" : string.Empty);
            return _entities
                .FromSqlRaw(query, filterSearch);
        }

        public virtual async Task<T> GetAsync(GetByIdParams parameters)
        {
            //return await _entities.FindAsync(id);
            return await GetQuery(parameters).FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetAsync(long id, bool noTracking = false, params string[] includes)
        {
            //return await _entities.FindAsync(id);
            return await GetAsync(new GetByIdParams(id, noTracking, includes));
        }

        public virtual T Get(GetByIdParams parameters)
        {
            return GetQuery(parameters).FirstOrDefault();
        }

        public virtual T Get(long id, bool noTracking = false, params string[] includes)
        {
            return Get(new GetByIdParams(id, noTracking, includes));
        }

        public virtual T InsertReturnObj(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Add(entity);
            save();
            return entity;
        }

        public virtual T UpdateReturnObj(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Update(entity);
            save();
            return entity;
        }

        public virtual T Attach(T entity, bool isUpdate = false)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (isUpdate)
                _context.Attach(entity).State = EntityState.Modified;
            else
                _entities.Attach(entity);
            
            save();
            return entity;
        }

        public virtual bool InsertReturnBool(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Add(entity);
            return save();
        }

        public virtual bool UpdateReturnBool(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Update(entity);
            return save();
        }

        public virtual bool LogicDelete(T entity, string property, bool value = true)
        {
            var idName = _context.Model.FindEntityType(typeof(T))
                .FindProperty(property)?.Name;
            if (idName == null) throw new ArgumentNullException();
            entity.GetType().GetProperty(idName).SetValue(entity, value);
            _context.Entry(entity).State = EntityState.Modified;
            return save();
        }

        public virtual bool Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Remove(entity);
            return save();
        }

        public IQueryable<T> GetQuery(GetByIdParams parameters)
        {
            var idName = _context.Model.FindEntityType(typeof(T))
                .FindPrimaryKey().Properties.Single().Name;
            var result = _entities
                .Where(x => EF.Property<int>(x, idName) == parameters.Id);
            if (parameters.Includes != null && parameters.Includes?.Length > 0)
                foreach (var item in parameters.Includes)
                    result = result.Include(item);
            if (parameters.AsNoTracking) result = result.AsNoTracking();
            return result;
        }

        public IQueryable<T> GetQuery(long id, bool noTracking = false, params string[] includes)
        {
            return GetQuery(new GetByIdParams(id, noTracking, includes));
        }

        public IQueryable<T> GetByPropertyQuery(GetByPropertyParams parameters)
        {
            if (string.IsNullOrEmpty(parameters.Property)) throw new ArgumentNullException();
            var idName = _context.Model.FindEntityType(typeof(T))
                .FindProperty(parameters.Property)?.Name;
            if (idName == null) throw new ArgumentNullException();
            IQueryable<T> results = null;
            if (string.IsNullOrEmpty(parameters.SearchItem.ToString()))
                results = _entities;
            else
                results = _entities
                    .Where(x => EF.Property<object>(x, idName) == parameters.SearchItem);
            if (parameters.Includes != null && parameters.Includes?.Length > 0)
                foreach (var item in parameters.Includes)
                    results = results.Include(item);
            if (parameters.AsNoTracking) results = results.AsNoTracking();
            return results;
        }

        public IQueryable<T> GetByPropertyQuery(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes)
        {
            return GetByPropertyQuery(new GetByPropertyParams(property, searchItem, noTracking, includes));
        }

        public bool AddRange(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");
            _entities.AddRange(entities);
            return save();
        }

        public bool RemoveRange(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");
            _entities.RemoveRange(entities);
            return save();
        }

        public void PatchItemById(string table, string column, string value, long id)
        {
            _context.Database.ExecuteSqlRaw(
                $"UPDATE public.{table} SET {column} = {value} WHERE id={id}");
        }

        private bool save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
