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

        public virtual T? GetById(long id)
        {
            return DataAccess.GetById(id);
        }

        public virtual long Update(T entity)
        {
            return DataAccess.Update(entity);
        }

        public virtual bool DeleteById(long id)
        {
            return DataAccess.DeleteById(id) > 0;
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
    }
}
