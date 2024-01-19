/**
 * Created by: Steve Bang
 * Create date: 2024-01-18
 * Description: This is the base class for all entities in the system.
 * Histories:
 * - [2024-01-18] Created.
 */

namespace SBase.Entity
{
    /// <summary>
    /// This is the base class for all entities in the system.<br/>
    /// It is used to provide a common base class for all entities.
    /// </summary>
    public  class BaseEntity :IBaseEntity
    {
        /// <summary>
        /// The column ID of the entity.
        /// </summary>
        public const string ColumnId = "ID";

        /// <summary>
        /// Gets or sets the identifier value.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseEntity() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public BaseEntity(long id) 
        {
            Id = id;
        }

        /// <inheritdoc/>
        public virtual IDictionary<string, object> BuildDeleteByIdParameters()
        {
            return new Dictionary<string, object>()
            {
                {ColumnId, Id }
            };
        }

        /// <inheritdoc/>
        public virtual IDictionary<string, object> BuildGetByIdParameters()
        {
            return new Dictionary<string, object>()
            {
                {ColumnId, Id }
            };
        }

        /// <inheritdoc/>
        public virtual IDictionary<string, object> BuildInsertParameters()
        {
            return new Dictionary<string, object>()
            {
                {ColumnId, Id }
            };
        }

        /// <inheritdoc/>
        public virtual IDictionary<string, object> BuildUpdateParameters()
        {
            return new Dictionary<string, object>()
            {
                {ColumnId, Id }
            };
        }
    }
}
