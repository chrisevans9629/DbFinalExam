using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFinalExam
{
    public partial class AddEstimate : Form
    {
        public AddEstimate()
        {
            InitializeComponent();
        }

        private void AddEstimate_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            comboBoxCustomer.BindQuery("select * from Customer", "CompanyName");
            comboBoxBusCon.BindQuery("select * from Consultant c, BusinessConsultant bc where bc.EmployeeID = c.EmployeeID",
                "LastName");
            comboBoxServices.BindQuery(
                "select ServiceId, (CONVERT(varchar(10), ServiceId) + '-' + Description) as FullName from Service", "FullName");
            this.dataGridView1.BindQuery("select * from Estimate");
            this.dateTimePicker.Value = DateTime.Today;
            this.textBoxAmount.Text = "0";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            dateTimePicker.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
            textBoxAmount.Text = row.Cells["Amount"].Value.ToString();
          
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listBoxServices.Items.Add(comboBoxServices.SelectedItem);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Sql.Exe((p,t)=> 
            {
                p.Execute("insert into Estimate() values ()",null,t);

                foreach (var item in listBoxServices.Items)
                {
                    p.Execute("insert into Estimate_Has_Service() values ()", null, t);
                }
            });
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
