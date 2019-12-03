using Dapper;
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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        public IEnumerable<Location> Locations
        {
            get => dataGridView1.DataSource as IEnumerable<Location>;
            set => dataGridView1.DataSource = value;
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            Locations = new List<Location>();
            button1.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var loc = Locations.ToList();

                if(int.TryParse(textBoxCustomerId.Text, out var customerId) &&
                    int.TryParse(textBoxLocSize.Text, out var size) &&
                    int.TryParse(textBoxLocId.Text, out var locId))
                {
                    loc.Add(new Location()
                    {
                        BuildingSize = size,
                        City = textBoxLocCity.Text,
                        CustomerId = customerId,
                        LocationId = locId,
                        Street = textBoxLocStrt.Text,
                        Telephone = textBoxLocTel.Text,
                        ZipCode = textBoxLocZip.Text
                    });
                    Locations = loc;
                    button1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Size, CustomerId, or LocationId not a number");
                }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(Connection.ConnectionStr))
            {

                db.Open();
                var tran = db.BeginTransaction();
                try
                {
                    db.Execute("insert into Customer() values ()", null, tran);

                    foreach (var location in Locations)
                    {
                        db.Execute("insert into Location() values ()", null, tran);
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tran.Rollback();
                }
            }
        }
    }
}
