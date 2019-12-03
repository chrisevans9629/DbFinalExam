using System;
using System.Data.SqlClient;

namespace DbFinalExam
{
    public static class Sql
    {
        public static T Exe<T>(Func<SqlConnection,T> result)
        {
            using (var con = new SqlConnection(Connection.ConnectionStr))
            {
                con.Open();
                return result(con);
            }
           
        }
    }
}