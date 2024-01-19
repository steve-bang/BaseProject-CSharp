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
        protected abstract D DAO { get; set; }

        public BaseRepository() { }

        public virtual long Create(T entity)
        {
            return DAO.Create(entity);
        }

        public virtual T GetById(long id)
        {
            return DAO.GetById(id);
        }

        public virtual long Update(T entity)
        {
            return DAO.Update(entity);
        }

        public virtual long DeleteById(long id)
        {
            return DAO.DeleteById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DAO.GetAll();
        }

        public virtual IEnumerable<T> GetAll(IBaseFilter filter)
        {
            return DAO.GetAll(filter);
        }

        public virtual CPageable<T> GetPageble(IBaseFilter filter)
        {
            long totalItems;
            IEnumerable<T> entities = DAO.GetAll(filter, out totalItems);

            return new CPageable<T>(entities, totalItems, filter);
        }
    }
}
