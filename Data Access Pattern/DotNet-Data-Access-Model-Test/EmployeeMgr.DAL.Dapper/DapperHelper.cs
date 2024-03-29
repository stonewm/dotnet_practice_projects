﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgr.DAL.Dapper
{
    public class DapperHelper
    {
        private String connStr = @"Server=localhost\sqlexpress;Database=stonetest;Integrated Security=True;";
        static IDbConnection dbConnection = new SqlConnection();

        public DapperHelper()
        {
            dbConnection.ConnectionString = connStr;
        }

        public IEnumerable<T> Query<T>(String sql, object pms = null)
        {
            return dbConnection.Query<T>(sql, pms);
        }

        public IEnumerable<T> QueryStoredProc<T>(String spName, object pms = null)
        {
            return dbConnection.Query<T>(spName, pms, commandType: CommandType.StoredProcedure);
        }

        public T QueryFirst<T>(String sql, object pms = null)
        {
            return dbConnection.QueryFirst<T>(sql, pms);
        }

        public T QueryFirstStoredProc<T>(String spName, object pms = null)
        {
            return dbConnection.QueryFirst<T>(spName, pms, commandType: CommandType.StoredProcedure);
        }

        public int Execute(String sql, object pms = null)
        {
            return dbConnection.Execute(sql, pms);
        }

        public int ExecuteStoredProc(String spName, object pms = null)
        {
            return dbConnection.Execute(spName, pms, commandType: CommandType.StoredProcedure);
        }
    }
}
