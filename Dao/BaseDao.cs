using SBase.DbContext;
using SBase.Entity;
using SBase.Filter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public long Create(T entity)
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
        public long DeleteById(long id)
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
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAll(IBaseFilter filter)
        {
            try
            {
                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(ListProcedureName, filter.BuildToPatameters());

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
        public IEnumerable<T> GetAll(IBaseFilter filter, out long totalItems)
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
        public T GetById(long id)
        {
            try
            {
                IBaseEntity baseEntity = new BaseEntity(id);

                DataTable dataTable = DbContextProvider.ExecuteStoredProcedure(GetProcedureName, baseEntity.BuildGetByIdParameters());

                if (dataTable == null)
                    return Enumerable.Empty<T>().First();
                else
                    return dataTable.AsEnumerable().Select(ConvertDataRowToEntity).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public long Update(T entity)
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
