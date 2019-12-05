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
            comboBoxBusCon.BindQuery("select *,(FirstName + ' ' + LastName) as Name from Consultant c, BusinessConsultant bc where bc.EmployeeID = c.EmployeeID",
                "Name");
            comboBoxServices.BindQuery(
                "select ServiceId, (CONVERT(varchar(10), ServiceId) + '-' + Description) as FullName from Service", "FullName");
            this.dataGridView1.BindQuery("select * from Estimate");
            this.dateTimePicker.Value = DateTime.Today;
            this.textBoxAmount.Text = "0";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

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
            Sql.Exe((p, t) =>
            {
                p.Execute("INSERT INTO [dbo].[Estimate] ([EstimateID] ,[Date] ,[Amount] ,[BusinessConsultant], CustomerID) VALUES (@EstimateId ,@Date ,@Amount ,@BusinessConsultant, @CustomerID)",
                    new
                    {
                        EstimateId = textBoxEstId.Text,
                        Date = dateTimePicker.Value,
                        Amount = textBoxAmount.Text,
                        BusinessConsultant = comboBoxBusCon.SelectedItem.GetDataRowValue("EmployeeID"),
                        CustomerID = comboBoxCustomer.SelectedItem.GetDataRowValue("CustomerID")
                    }, t);

                foreach (Service item in listBoxServices.Items)
                {
                    p.Execute("insert into EstimateHasService(EstimateID, ServiceID) values (@Estimate,@Service)", new { Estimate = textBoxEstId.Text, Service = item.ServiceID }, t);
                }
            });

            Refresh();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Sql.Exe((p, t) =>
            {
                p.Execute(@"
UPDATE [dbo].[Estimate] 
set [Date] = @Date,[Amount] = @Amount,[BusinessConsultant] = @BusinessConsultant, [CustomerID] = @CustomerID 
where EstimateId = @EstimateId 
",
                    new
                    {
                        EstimateId = textBoxEstId.Text,
                        Date = dateTimePicker.Value,
                        Amount = textBoxAmount.Text,
                        BusinessConsultant = comboBoxBusCon.SelectedItem.GetDataRowValue("EmployeeID"),
                        CustomerID = comboBoxCustomer.SelectedItem.GetDataRowValue("CustomerID")
                    }, t);

                //foreach (Service item in listBoxServices.Items)
                //{
                //    p.Execute("update Estimate_Has_Service set (EstimateID, ServiceID) values (@Estimate,@Service)", new { Estimate = textBoxEstId.Text, Service = item.ServiceID }, t);
                //}
            });
            Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Sql.Exe((p, t) =>
            {
                p.Execute("delete EstimateHasService where EstimateId = @id", new { id = textBoxEstId.Text }, t);
                p.Execute("delete Estimate where EstimateID = @id", new {id = textBoxEstId.Text},t);
            });
            Refresh();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            dateTimePicker.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
            textBoxAmount.Text = row.Cells["Amount"].Value.ToString();
            textBoxEstId.Text = row.Cells["EstimateID"].Value.ToString();
            comboBoxBusCon.SelectedItem =
                comboBoxBusCon.Items.Cast<DataRowView>().FirstOrDefault(p => p.GetDataRowValue("EmployeeID") == row.Cells["BusinessConsultant"].Value.ToString());
            comboBoxCustomer.SelectedItem = comboBoxCustomer.Items.Cast<DataRowView>().FirstOrDefault(p =>
                p.GetDataRowValue("CustomerID") == row.Cells["CustomerID"].Value.ToString());

            listBoxServices.Items.Clear();
            var services = Sql.Exe(p =>
                p.Query<Service>(
                    @"
select s.ServiceId, (CONVERT(varchar(10), s.ServiceId) + '-' + Description) as FullName 
from Service s, EstimateHasService ehs 
where s.ServiceId = ehs.ServiceID and ehs.EstimateID = @EstimateID",
                    new { EstimateID = row.Cells["EstimateID"].Value.ToString() }));

            foreach (var service in services)
            {
                listBoxServices.Items.Add(service);
            }
        }

        private void TextBoxEstId_TextChanged(object sender, EventArgs e)
        {

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
