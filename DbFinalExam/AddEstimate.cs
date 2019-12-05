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
            if (comboBoxServices.SelectedItem is DataRowView view)
            {
                listBoxServices.Items.Add(comboBoxServices.SelectedItem.DataRowViewToObject<Service>());
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Sql.Exe((p,t)=> 
            {
                p.Execute("INSERT INTO [dbo].[Estimate] ([EstimateID] ,[Date] ,[Amount] ,[BusinessConsultant], CustomerID) VALUES (@EstimateId ,@Date ,@Amount ,@BusinessConsultant, @CustomerID)",
                    new
                    {
                        EstimateId = textBoxEstId.Text,
                        Date = dateTimePicker.Value,
                        Amount = textBoxAmount.Text,
                        BusinessConsultant = comboBoxBusCon.SelectedItem.GetDataRowValue("EmployeeID"),
                        CustomerID = comboBoxCustomer.GetDataRowValue("CustomerID")
                    },t);

                foreach (var item in listBoxServices.Items)
                {
                    p.Execute("insert into Estimate_Has_Service(EstimateID, ServiceID) values (@Estimate,@Service)", new {Estimate = textBoxEstId.Text, Service = item.GetDataRowValue("ServiceID")}, t);
                }
            });

            Refresh();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }

    public class Service
    {
        public int ServiceID { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return $"{FullName}";
        }
    }
}
