using SBase.Entity;
using SBase.Filter;
using SBase.Pageable;

namespace SBase.Repository
{
    public interface IBaseRepository<T> 
        where T : IBaseEntity
    {
        /// <summary>
        /// Creates a new record in the database then returns the id of the new record.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The id of the new record.</returns>
        long Create(T entity);

        /// <summary>
        /// Gets a entity from the database by an id, then converts it to an entity.
        /// </summary>
        /// <param name="entityId">The id of the record to get.</param>
        /// <returns>The entity.</returns>
        T? GetById(long id);

        /// <summary>
        /// Updates a entity in the database then returns the affected rows.
        /// </summary>
        /// <param name="entity">The entity data to update.</param>
        /// <returns>The affected rows.</returns>
        long Update(T entity);

        /// <summary>
        /// Deletes a entities from the database then returns the affected rows.
        /// </summary>
        /// <param name="id">The Id of the entity to delete.</param>
        /// <returns>The affected rows.</returns>
        bool DeleteById(long id);

        /// <summary>
        ///  Gets all entities from the database.
        /// </summary>
        /// <returns>The entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets all entities from the database with the given filter
        /// </summary>
        /// <param name="filter">The filter object to apply.</param>
        /// <returns>The entities.</returns>
        IEnumerable<T> GetAll(IBaseFilter filter);

        /// <summary>
        /// Gets all entities from the database with the given filter.
        /// </summary>
        /// <param name="filter">The filter object to apply.</param>
        /// <returns>The pageable object using type entity.</returns>
        CPageable<T> GetPageble(IBaseFilter filter);

    }
}
