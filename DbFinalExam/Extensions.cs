using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DbFinalExam
{
    public static class Extensions
    {

        public static void BindQuery(this ComboBox cbo, string sql, string sqlColumnName)
        {
            var dbConnectionString = Connection.ConnectionStr;
            using (var newAdapter = new SqlDataAdapter())
            using (var newDataset = new DataSet())
            using (var openConnection = new SqlConnection(dbConnectionString))
            {
                newAdapter.SelectCommand = new SqlCommand(sql, openConnection);
                newAdapter.SelectCommand.Connection = openConnection;

                openConnection.Open();
                newAdapter.Fill(newDataset, "test");

                cbo.DataSource = newDataset;
                cbo.DisplayMember = $"test.{sqlColumnName}";
                cbo.SelectedIndex = 0;
            }
        }


        public static void BindQuery(this Label lbl, string sql, string sqlColumnName)
        {
            var dbConnectionString = Connection.ConnectionStr;
            using (var newAdapter = new SqlDataAdapter())
            using (var newDataset = new DataSet())
            using (var openConnection = new SqlConnection(dbConnectionString))
            {
                newAdapter.SelectCommand = new SqlCommand(sql, openConnection);
                newAdapter.SelectCommand.Connection = openConnection;

                openConnection.Open();
                newAdapter.Fill(newDataset, "test");

                lbl.DataBindings.Add("Text", newDataset, $"test.{sqlColumnName}");
            }

        }


        public static void BindQuery(this DataGridView dgv, string sql)
        {
            var dbConnectionString = Connection.ConnectionStr;
            using (var newAdapter = new SqlDataAdapter())
            using (var newDataset = new DataSet())
            using (var openConnection = new SqlConnection(dbConnectionString))
            {
                newAdapter.SelectCommand = new SqlCommand(sql, openConnection);
                newAdapter.SelectCommand.Connection = openConnection;

                openConnection.Open();
                newAdapter.Fill(newDataset, "test");

                dgv.AutoGenerateColumns = true;
                dgv.DataSource = newDataset;
                dgv.DataMember = "test";
            }
              
        }
    }
}