using Dapper;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DbFinalExam
{
    public static class Sql
    {


        public static void Exe(Action<SqlConnection, SqlTransaction> result)
        {
            using (var con = new SqlConnection(Connection.ConnectionStr))
            {
                con.Open();
                var tran = con.BeginTransaction();
                try
                {
                    result(con, tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tran.Rollback();
                }
                
            }

        }

        public static T Exe<T>(Func<SqlConnection, T> result)
        {
            using (var con = new SqlConnection(Connection.ConnectionStr))
            {
                con.Open();
                return result(con);
            }

        }
    }
}