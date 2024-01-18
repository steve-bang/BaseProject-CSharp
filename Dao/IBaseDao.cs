using SBase.Entity;
using SBase.Filter;

namespace SBase.Dao
{
    /// <summary>
    /// Defines the generic base interface for all DAOs in the system.<br/>
    /// It is used to provide a common base interface for all DAOs.
    /// </summary>
    public interface IBaseDao<T> where T : IBaseEntity
    {
        /// <summary>
        /// Creates a new record in the database then returns the id of the new record.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The id of the new record.</returns>
        long Create(T entity);

        /// <summary>
        /// Gets a record from the database by an id, then converts it to an entity.
        /// </summary>
        /// <param name="entityId">The id of the record to get.</param>
        /// <returns>The entity.</returns>
        T GetById (long id);

        /// <summary>
        /// Updates a record in the database then returns the affected rows.
        /// </summary>
        /// <param name="entity">The entity data to update.</param>
        /// <returns>The affected rows.</returns>
        long Update (T entity);

        /// <summary>
        /// Deletes a record from the database then returns the affected rows.
        /// </summary>
        /// <param name="id">The Id of the entity to delete.</param>
        /// <returns>The affected rows.</returns>
        long DeleteById (long id);

        /// <summary>
        ///  Gets all records from the database.
        /// </summary>
        /// <returns>The entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets all records from the database with the given filter
        /// </summary>
        /// <param name="filter">The filter object to apply.</param>
        /// <returns>The entities.</returns>
        IEnumerable<T> GetAll(IBaseFilter filter);

        /// <summary>
        /// Gets all records from the database with the given filter
        /// </summary>
        /// <param name="totalItems">The total number of records that match the filters.</param>
        /// <param name="filter">The filter object to apply.</param>
        /// <returns>The entities.</returns>
        IEnumerable<T> GetAll(IBaseFilter filter, out long totalItems);

    }
}
