using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace DbFinalExam
{
    public static class Extensions
    {
        public static string GetDataRowValue(this object obj, string column)
        {
            if (obj is DataRowView view)
            {
                return view.Row[column]?.ToString();
            }
            throw new InvalidOperationException($"{obj} is not a DataRowView");
        }

        public static T DataRowViewToObject<T>(this object obj) where T : new()
        {
            if (obj is DataRowView row)
            {
                var t = new T();

                foreach (var propertyInfo in t.GetType().GetProperties())
                {
                    propertyInfo.SetValue(t,row.Row[propertyInfo.Name]);
                }

                return t;
            }
            throw  new InvalidOperationException($"{obj} is not a DataRowView");
        }
        public static void BindQuery(this ComboBox cbo, string sql, string sqlColumnName)
        {
            var dbConnectionString = Connection.ConnectionStr;
            using (var newAdapter = new SqlDataAdapter())
            using (var openConnection = new SqlConnection(dbConnectionString))
            {
                var newDataset = new DataSet();
                    
                newAdapter.SelectCommand = new SqlCommand(sql, openConnection);
                newAdapter.SelectCommand.Connection = openConnection;

                openConnection.Open();
                newAdapter.Fill(newDataset, "test");

                cbo.DataSource = newDataset;
                cbo.DisplayMember = $"test.{sqlColumnName}";
                if (cbo.Items.Count > 0)
                    cbo.SelectedIndex = 0;
            }
        }


        public static void BindQuery(this Label lbl, string sql, string sqlColumnName)
        {
            var dbConnectionString = Connection.ConnectionStr;
            using (var newAdapter = new SqlDataAdapter())
            using (var openConnection = new SqlConnection(dbConnectionString))
            {
                var newDataset = new DataSet();
                newAdapter.SelectCommand = new SqlCommand(sql, openConnection);
                newAdapter.SelectCommand.Connection = openConnection;

                openConnection.Open();
                newAdapter.Fill(newDataset, "test");

                lbl.DataBindings.Add("Text", newDataset, $"test.{sqlColumnName}");
            }

        }


        public static void BindQuery(this DataGridView dgv, string sql, object parameters = null)
        {
            var dbConnectionString = Connection.ConnectionStr;
            using (var newAdapter = new SqlDataAdapter())
            using (var openConnection = new SqlConnection(dbConnectionString))
            {
                var newDataset = new DataSet();
                newAdapter.SelectCommand = new SqlCommand(sql, openConnection);
                newAdapter.SelectCommand.Connection = openConnection;
                if(parameters != null)
                {
                    foreach (var item in parameters.GetType().GetProperties())
                    {
                        newAdapter.SelectCommand.Parameters.AddWithValue("@" + item.Name, item.GetValue(parameters));
                    }
                }
                openConnection.Open();
                newAdapter.Fill(newDataset, "test");

                dgv.AutoGenerateColumns = true;
                dgv.DataSource = newDataset;
                dgv.DataMember = "test";
            }

        }
    }
}