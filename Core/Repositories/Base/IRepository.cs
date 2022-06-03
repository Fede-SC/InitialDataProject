using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techpork.Core.RepositoryParams;

namespace Techpork.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        IQueryable<T> GetAllQuery();

        Task<List<T>> GetAllByPropertyAsync(GetByPropertyParams parameters);
        Task<List<T>> GetAllByPropertyAsync(
           string property,
           object searchItem,
           bool noTracking = false,
           params string[] includes);

        Task<T> GetByPropertyAsync(GetByPropertyParams parameters);
        Task<T> GetByPropertyAsync(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes);
        
        List<T> GetAllByProperty(GetByPropertyParams parameters);
        List<T> GetAllByProperty(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes);

        T GetByProperty(GetByPropertyParams parameters);
        T GetByProperty(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes);
        
        IQueryable<T> SearchByProperty(string filter, string property);
        IQueryable<T> SearchByProperties(string filter, params string[] properties);

        Task<T> GetAsync(GetByIdParams parameters);
        Task<T> GetAsync(long id, bool noTracking = false, params string[] includes);

        T Get(GetByIdParams parameters);
        T Get(long id, bool noTracking = false, params string[] includes);

        T InsertReturnObj(T entity);
        T UpdateReturnObj(T entity);
        T Attach(T entity, bool isUpdate = false);
        bool InsertReturnBool(T entity);
        bool UpdateReturnBool(T entity);
        bool LogicDelete(T entity, string property, bool value = true);
        bool Delete(T entity);
        void PatchItemById(string table, string column, string value, long id);
        bool AddRange(List<T> entities);
        bool RemoveRange(List<T> entities);
        IQueryable<T> GetQuery(GetByIdParams parameters);
        IQueryable<T> GetQuery(long id, bool noTracking = false, params string[] includes);

        IQueryable<T> GetByPropertyQuery(GetByPropertyParams parameters);
        IQueryable<T> GetByPropertyQuery(
            string property,
            object searchItem,
            bool noTracking = false,
            params string[] includes);
    }
}
