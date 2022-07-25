﻿using System;
using IndoSpacePrac.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IndoSpacePrac.Data.Repository
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// get array of records for a entity
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <returns></returns>
        IEnumerable<T> GetRecords(SqlCommand command);


        /// <summary>
        /// get record for a entity
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <returns></returns>
        T GetRecord(SqlCommand command);


        /// <summary>
        /// Execute A procedure
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <returns></returns>
        IEnumerable<T> ExecuteStoredProc(SqlCommand command);


        /// <summary>
        /// get array of records for a entity
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <param name="propertyMap">Maping of Class property to reader coloum.</param>
        /// <returns></returns>
        IEnumerable<T> GetRecords(SqlCommand command, IDictionary<string, string> propertyMap);

        /// <summary>
        /// get record for a entity
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <param name="propertyMap">Maping of Class property to reader coloum.</param>
        /// <returns></returns>
        T GetRecord(SqlCommand command, IDictionary<string, string> propertyMap);
        /// <summary>
        /// ExecuteStoredProcedure
        /// </summary>
        /// <param name="command"></param>
        /// <returns>DataTable</returns>
        DataTable ExecuteStoredProcedure(SqlCommand command);

        /// <summary>
        /// Execute A procedure
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <param name="propertyMap">Maping of Class property to reader coloum.</param>
        /// <returns></returns>
        IEnumerable<T> ExecuteStoredProc(SqlCommand command, IDictionary<string, string> propertyMap);

        /// <summary>
        /// Execute A procedure
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <returns>Return last inserted records id</returns>
        int ExecuteProc(SqlCommand command);

        /// <summary>
        /// Execute A procedure
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <returns>Return object</returns>
        object ExecuteProcedure(SqlCommand command);

        object ExecuteQuery(SqlCommand command);

        ///Below 2 methods Added by Keshaw
        /// <summary>
        /// Execute A Query
        /// </summary>
        /// <param name="command">Sql Command with parameters or query.</param>
        /// <returns></returns>
        int ExecuteNonQuery(string query);
        /// <summary>
        /// ExecuteNonQueryProc
        /// </summary>
        /// <param name="command"></param>
        /// <returns>affacted Rows</returns>
        int ExecuteNonQueryProc(SqlCommand command);

        /// <summary>
        /// Get Cache Key using id patern and Mysql command
        /// </summary>
        /// <param name="KeyPrefix">Prefix used for key like AreaName.ServiceName</param>
        /// <param name="KeyId">Id for the key like StockId or IndiceId</param>
        /// <param name="CMD">Command object For parameters</param>
        /// <returns></returns>
        string GetCacheKey(string KeyPrefix, object KeyId, SqlCommand CMD);

        /// <summary>
        /// Get Cache Key using id patern and Mysql command
        /// </summary>
        /// <param name="KeyPrefix">Prefix used for key like AreaName.ServiceName</param>
        /// <param name="CMD">Command object For parameters</param>
        string GetCacheKey(string KeyPrefix, SqlCommand CMD);

        /// <summary>
        /// Get Cache Key using id patern and Mysql command
        /// </summary>
        /// <param name="KeyPrefix">Prefix used for key like AreaName.ServiceName</param>
        /// <param name="KeyId">Id for the key like StockId or IndiceId</param>
        /// <param name="Parameter">Command object For parameters</param>
        /// <returns></returns>
        string GetCacheKey(string KeyPrefix, object KeyId, string Parameter);

        /// <summary>
        /// Get Cache Key using id patern and Mysql command
        /// </summary>
        /// <param name="KeyPrefix">Prefix used for key like AreaName.ServiceName</param>
        /// <param name="KeyId">Id for the key like StockId or IndiceId</param>
        /// <returns></returns>
        string GetCacheKey(string KeyPrefix, object KeyId);

    }
}
