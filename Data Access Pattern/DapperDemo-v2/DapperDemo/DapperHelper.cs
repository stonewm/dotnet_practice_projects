﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DapperDemo
{
    public class DapperHelper
    {
        private String connStr = @"Server=localhost\sqlexpress;Database=stonetest;Integrated Security=True;";
        static IDbConnection dbConnection = new SqlConnection();

        public DapperHelper() {
            dbConnection.ConnectionString = connStr;
        }

        public IEnumerable<T> Query<T>(String sql, object pms = null) {
            return dbConnection.Query<T>(sql, pms);
        }

        public T QueryFirst<T>(String sql, object pms = null) {
            return dbConnection.QueryFirst<T>(sql, pms);
        }

        public int Execute(String sql, object pms = null) {
            return dbConnection.Execute(sql, pms);
        }

    }
}
