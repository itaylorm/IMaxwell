using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using IMaxwell.Data.Core;

namespace IMaxwell.Data.SqlServer
{
    /// <summary>
    /// Provides access to passed sql server database
    /// </summary>
    public class QueryProvider : IQueryProvider
    {

        private readonly string _connectionString;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes underlying connection string
        /// </summary>
        /// <param name="serverName">Sql Server Name</param>
        /// <param name="databaseName">Sql Server Database Name</param>
        public QueryProvider(string serverName, string databaseName)
        {

            var builder = new SqlConnectionStringBuilder
            {
                IntegratedSecurity = true,
                DataSource = serverName,
                InitialCatalog = databaseName
            };

            _connectionString = builder.ConnectionString;

        }

        /// <summary>
        /// Assemble information about connecting to the database
        /// </summary>
        /// <returns>Returns appropriate connection which contains connection information</returns>
        public virtual IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Assemble information about the query to send to the database
        /// </summary>
        /// <param name="command">Query to send to database</param>
        /// <param name="connection">Connection information for the database</param>
        /// <returns>Returns appropriate command which contains query information</returns>
        public virtual IDbCommand CreateCommand(string command, IDbConnection connection)
        {
            return new SqlCommand(command, (SqlConnection)connection);
        }

        /// <summary>
        /// Assemble data adapter for processing command and returning data
        /// </summary>
        /// <param name="command">Information for the query to send</param>
        /// <returns>Returns appropriate adapter which will return records</returns>
        public virtual IDbDataAdapter CreateDataAdapter(IDbCommand command)
        {
            var sqlCommand = command as SqlCommand;

            if (sqlCommand != null)
            {
                return new SqlDataAdapter(sqlCommand);
            }

            throw new ArgumentException("Command must be a SqlCommand");

        }

        /// <summary>
        /// Retrieve data associated with the passed query string
        /// </summary>
        /// <param name="procedure">Name of procedure which will return data</param>
        /// <returns>Returns data associated with the query string</returns>
        public DataTable RetrieveData(string procedure)
        {

            var dataTable = new DataTable();

            try
            {
                using (var connection = CreateConnection())
                {

                    connection.Open();

                    using (var command = CreateCommand(procedure, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var adapter = CreateDataAdapter(command);

                        using (var dataSet = new DataSet())
                        {
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0)
                            {
                                dataTable = dataSet.Tables[0];
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Log.Error("Retrieve Contacts failed with a database error", ex);
            }
            catch (Exception ex)
            {
                Log.Error("Retrieve Contacts failed with a general error", ex);
            }

            return dataTable;

        }

        /// <summary>
        /// Retrieve data by stored procedure with the passed identifier
        /// </summary>
        /// <param name="procedure">Name of command for retrieving data</param>
        /// <param name="idParameterName">Id parameter used by the procedure</param>
        /// <param name="id">Unique Identifier for the data to return</param>
        /// <returns>Returns data associated with the id</returns>
        public virtual DataTable RetrieveData(string procedure, string idParameterName, int id)
        {

            var dataTable = new DataTable();

            try
            {
                using (var connection = CreateConnection())
                {

                    connection.Open();

                    using (var command = CreateCommand(procedure, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var idParameter = new SqlParameter(idParameterName, SqlDbType.Int) {Value = id};
                        command.Parameters.Add(idParameter);

                        var adapter = CreateDataAdapter(command);

                        using (var dataSet = new DataSet())
                        {
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0)
                            {
                                dataTable = dataSet.Tables[0];
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Log.Error("Retrieve Contacts failed with a database error", ex);
            }
            catch (Exception ex)
            {
                Log.Error("Retrieve Contacts failed with a general error", ex);
            }

            return dataTable;
        }
    }
}
