using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace DbFinalExam
{

   


    public static class Sql
    {
        public static T Exe<T>(Func<SqlConnection,T> result)
        {
            using var con = new SqlConnection(Connection.ConnectionStr);
            con.Open();
            return result(con);
        }
    }


    public static class Connection
    {
        public static string Database { get; set; } 
        public static string Server { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string ConnectionStr => 
            $@"Data Source={Server};Initial Catalog={Database};User Id={UserName};Password={Password}";
    }

    static class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
