using SBase.Dao;
using SBase.Entity;
using SBase.Filter;
using SBase.Pageable;

namespace SBase.Repository
{
    public abstract class BaseRepository<T, D> : IBaseRepository<T>
        where T : IBaseEntity
        where D : IBaseDao<T>
    {
        protected abstract D DataAccess { get; set; }

        public BaseRepository() { }

        public virtual long Create(T entity)
        {
            return DataAccess.Create(entity);
        }

        public virtual async Task<long> CreateAsync(T entity)
        {
            return await DataAccess.CreateAsync(entity);
        }

        public virtual T? GetById(long id)
        {
            return DataAccess.GetById(id);
        }

        public virtual async Task<T?> GetByIdAsync(long id)
        {
            return await DataAccess.GetByIdAsync(id);
        }


        public virtual long Update(T entity)
        {
            return DataAccess.Update(entity);
        }

        public virtual bool DeleteById(long id)
        {
            return DataAccess.DeleteById(id) > 0;
        }

        public virtual async Task<bool> DeleteByIdAsync(long id)
        {
            return await DataAccess.DeleteByIdAsync(id) > 0;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DataAccess.GetAll();
        }

        public virtual IEnumerable<T> GetAll(IBaseFilter filter)
        {
            return DataAccess.GetAll(filter);
        }

        public virtual CPageable<T> GetPageble(IBaseFilter filter)
        {
            long totalItems;
            IEnumerable<T> entities = DataAccess.GetAll(filter, out totalItems);

            return new CPageable<T>(entities, totalItems, filter);
        }

        public async Task<IEnumerable<T>> GetAllAsync(IBaseFilter filter)
        {
            return await DataAccess.GetAllAsync(filter);
        }

        public async Task<CPageable<T>> GetPagebleAsync(IBaseFilter filter)
        {
            long totalItems = 0;
            IEnumerable<T> entities = await Task.Run(() => DataAccess.GetAll(filter, out totalItems));

            return new CPageable<T>(entities, totalItems, filter);
        }
    }
}
