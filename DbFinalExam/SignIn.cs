using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFinalExam
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connection.Database = textBoxDb.Text;
            Connection.Password = textBoxPwd.Text;
            Connection.Server = textBoxServer.Text;
            Connection.UserName = textBoxUsr.Text;

            try
            {
                using (var db = new SqlConnection(Connection.ConnectionStr))
                {
                    db.OpenAsync();
                }
                Hide();
                var main = new Main();
                main.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.ToString());
            }

        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            textBoxDb.Text = Connection.Database;
            textBoxPwd.Text = Connection.Password;
            textBoxServer.Text = Connection.Server;
            textBoxUsr.Text = Connection.UserName;
        }
    }
}
