using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SBase.DbContext
{
    public static class DbContextProvider
    {
        /// <summary>
        /// This is the connection string is use to connect your database.
        /// </summary>
        public static string _connectionString { get; set; } = string.Empty;

        /// <summary>
        /// This is the output parameter total rows default in the system. You can override method to access your output parameter. 
        /// </summary>
        public static string _outParamterTotalRows { get; set; } = "Total_Rows";

        private static DataTable ReadData( SqlCommand sqlCommand )
        {
            try
            {
                var dataTable = new DataTable();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    dataTable.Load(sqlDataReader);
                }

                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Execute a stored procedure and return the results.
        /// </summary>
        /// <param name="storedProcedureName">The stored procedure name</param>
        /// <returns>The results of the stored procedure</returns>
        public static DataTable Execute( string storedProcedureName)
        {
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    using (var sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();

                        dataTable = ReadData(sqlCommand);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally 
                { 
                    sqlConnection.Close(); 
                }

                return dataTable;
            }
        }

        /// <summary>
        /// Execute a stored procedure with indexed params and return the results
        /// </summary>
        /// <param name="storedProcedureName">The stored procedure name</param>
        /// <param name="parameters">The parameters of the stored procedure</param>
        /// <returns>The results of the stored procedure</returns>
        public static DataTable ExecuteStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        )
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var dataTable = new DataTable();
                try
                {
                    using (var sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add the parameters to the command
                        foreach (var parameter in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
                        }

                        sqlConnection.Open();
                        dataTable = ReadData(sqlCommand);
                    }
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return dataTable;
            }
        }

        /// <summary>
        /// Execute a stored procedure with indexed params and return the results
        /// </summary>
        /// <param name="storedProcedureName">The stored procedure name</param>
        /// <param name="parameters">The parameters of the stored procedure</param>
        /// <param name="totalRows">The total rows output paramters.</param>
        /// <returns>The results of the stored procedure</returns>
        public static DataTable ExecuteStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters,
            out long totalRows
        )
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var dataTable = new DataTable();

                try
                {
                    using (var sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add the parameters to the command
                        foreach (var parameter in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
                        }

                        // Add output parameter
                        SqlParameter outputParamTotalRows = new SqlParameter("@" + _outParamterTotalRows, SqlDbType.BigInt);
                        outputParamTotalRows.Direction = ParameterDirection.Output;

                        sqlCommand.Parameters.Add(outputParamTotalRows);

                        sqlConnection.Open();

                        using ( SqlDataReader sqlDataReader = sqlCommand.ExecuteReader() )
                        {
                            dataTable.Load(sqlDataReader);
                        }

                        // Sets the total rows output parameter
                        totalRows = Convert.ToInt64(outputParamTotalRows.Value);

                    }
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;
            }
        }
    }
}
