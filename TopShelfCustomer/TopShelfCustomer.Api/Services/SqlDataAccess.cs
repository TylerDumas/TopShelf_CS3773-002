using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TopShelfCustomer.Api.Services {

    /// <summary>
    /// SqlDataAccess:
    /// 
    /// Helper class to allow for access to the TopShelf
    /// database. Contains functionality for reading/writing to
    /// the database.
    /// </summary>
    public class SqlDataAccess {

        /// <summary>
        /// GetConnectionString:
        /// 
        /// Helper method to return the value of the connection string,
        /// within the configuration manager, at index "name".
        /// </summary>
        /// <param name="name"> The key for the connection string value </param>
        /// <returns> the value of the connection string for "name" </returns>
        public string GetConnectionString( string name ) {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// LoadData:
        /// 
        /// Acts as a read method for the database.
        /// </summary>
        /// <typeparam name="T"> The object type to load from the database </typeparam>
        /// <typeparam name="U"> The type of the parameters object to query with </typeparam>
        /// <param name="storedProcedure"> The SQL procedure to use on the database </param>
        /// <param name="parameters"> The parameters for the SQL query </param>
        /// <param name="connectionStringName"> The shortened name of the SQL connection string </param>
        /// <returns> A list of Type T objects returned from the database query </returns>
        public List<T> LoadData<T, U>( string storedProcedure, U parameters, string connectionStringName ) {

            string connectionString = GetConnectionString( connectionStringName );      //The full connection string

            using( IDbConnection connection = new SqlConnection( connectionString ) ) {     //Database connection and Query
                List<T> rows = connection.Query<T>( storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure ).ToList();
                return rows;
            }
        }

        /// <summary>
        /// SaveData:
        /// 
        /// Acts as a write method for the database.
        /// </summary>
        /// <typeparam name="T"> The type of the parameters passed to the SQL query </typeparam>
        /// <param name="storedProcedure"> The SQL procedure to use on the database </param>
        /// <param name="parameters"> The parameters for the SQL query </param>
        /// <param name="connectionStringName"> The shortened name of the SQL connection string </param>
        public void SaveData<T>( string storedProcedure, T parameters, string connectionStringName ) {

            string connectionString = GetConnectionString( connectionStringName );      //The full connection string

            using ( IDbConnection connection = new SqlConnection( connectionString ) ) {        //Database connection and Query
                connection.Execute( storedProcedure,
                    parameters, commandType: CommandType.StoredProcedure );
            }
        }
    }
}