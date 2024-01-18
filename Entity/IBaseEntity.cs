/**
 * Created by: Steve Bang
 * Create date: 2024-01-18
 * Description: This is the base interface for all entities in the system.
 * Histories:
 * - [2024-01-18] Created.
 */

namespace SBase.Entity
{
    /// <summary>
    /// This is the base interface for all entities in the system.  
    /// It is used to provide a common base interface for all entities.
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// The unique identifier for the entity.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Exports the entity's properties to a dictionary for use in an get statement.
        /// </summary>
        IDictionary<string, object> BuildGetByIdParameters();

        /// <summary>
        /// Exports the entity's properties to a dictionary for use in an delete statement.
        /// </summary>
        IDictionary<string, object> BuildDeleteByIdParameters();

        /// <summary>
        /// Exports the entity's properties to a dictionary for use in an insert statement.
        /// </summary>
        IDictionary<string, object> BuildInsertParameters();

        /// <summary>
        /// Exports the entity's properties to a dictionary for use in an update statement.
        /// </summary>
        IDictionary<string, object> BuildUpdateParameters();

    }
}
