using SBase.DbContext;
using SBase.Entity;
using SBase.Filter;
using System.Data;

namespace SBase.Dao
{
    /// <summary>
    /// Defines the base class for all DAOs in the system.
    /// </summary>
    public abstract class BaseDao <T> : IBaseDao<T> 
        where T : IBaseEntity
    {
        /// <summary>
        /// The name of the stored procedure to insert an entity.
        /// </summary>
        protected string InsertProcedureName { get; set; } = string.Empty;

        /// <summary>
        /// The name of the stored procedure to get an entity by id.
        /// </summary>
        protected string GetProcedureName { get; set; } = string.Empty;

        /// <summary>
        /// The name of the stored procedure to get all entities.
        /// </summary>
        protected string ListProcedureName { get; set; } = string.Empty;

        /// <summary>
        /// The name of the stored procedure to update an entity.
        /// </summary>
        protected string UpdateProcedureName { get; set; } = string.Empty;

        /// <summary>
        /// The name of the stored procedure to delete an entity.
        /// </summary>
        protected string DeleteProcedureName { get; set; } = string.Empty;

        /// <summary>
        /// The function to convert a data row to an entity. This method must be override for another dao entity.
        /// </summary>
        /// <param name="dataRow">The data row to convert.</param>
        /// <returns>The entity.</returns>
        protected abstract T ConvertDataRowToEntity(DataRow dataRow);

        /// <inheritdoc/>
        public virtual long Create(T entity)
        {
            try
            {
                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(InsertProcedureName, entity.BuildInsertParameters());

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (long)dataTable.Rows[0][0];
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<long> CreateAsync(T entity)
        {
            try
            {
                DataTable dataTable = await DbContextProvider.ExecuteStoredProcedureAsync(InsertProcedureName, entity.BuildInsertParameters());

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (long)dataTable.Rows[0][0];
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual long DeleteById(long id)
        {
            try
            {
                IBaseEntity baseEntity = new BaseEntity(id);

                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(DeleteProcedureName, baseEntity.BuildDeleteByIdParameters());

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (long)dataTable.Rows[0][0];
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<long> DeleteByIdAsync(long id)
        {
            try
            {
                IBaseEntity baseEntity = new BaseEntity(id);

                DataTable dataTable = await DbContextProvider.ExecuteStoredProcedureAsync(DeleteProcedureName, baseEntity.BuildDeleteByIdParameters());

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (long)dataTable.Rows[0][0];
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> GetAll(IBaseFilter filter)
        {
            try
            {
                long totalItems = 0;
                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(ListProcedureName, filter.BuildToPatameters(), out totalItems);

                if (dataTable == null)
                    return Enumerable.Empty<T>();
                else
                    return dataTable.AsEnumerable().Select(ConvertDataRowToEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<T>> GetAllAsync(IBaseFilter filter)
        {
            try
            {
                long totalItems = 0;
                DataTable dataTable = await Task.Run(() => DbContextProvider.ExecuteStoredProcedure(ListProcedureName, filter.BuildToPatameters(), out totalItems));

                if (dataTable == null)
                    return Enumerable.Empty<T>();
                else
                    return dataTable.AsEnumerable().Select(ConvertDataRowToEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> GetAll(IBaseFilter filter, out long totalItems)
        {
            try
            {
                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(ListProcedureName, filter.BuildToPatameters(), out totalItems);

                if (dataTable == null)
                    return Enumerable.Empty<T>();
                else
                    return dataTable.AsEnumerable().Select(ConvertDataRowToEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual T? GetById(long id)
        {
            try
            {
                IBaseEntity baseEntity = new BaseEntity(id);

                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(GetProcedureName, baseEntity.BuildGetByIdParameters());

                if (dataTable == null)
                    return Enumerable.Empty<T>().First();
                else
                    return dataTable.AsEnumerable().Select(ConvertDataRowToEntity).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<T?> GetByIdAsync(long id)
        {
            try
            {
                IBaseEntity baseEntity = new BaseEntity(id);

                DataTable dataTable = await DbContextProvider.ExecuteStoredProcedureAsync(GetProcedureName, baseEntity.BuildGetByIdParameters());

                if (dataTable == null)
                    return Enumerable.Empty<T>().First();
                else
                    return dataTable.AsEnumerable().Select(ConvertDataRowToEntity).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual long Update(T entity)
        {
            try
            {
                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(UpdateProcedureName, entity.BuildUpdateParameters());

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (long)dataTable.Rows[0][0];
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
