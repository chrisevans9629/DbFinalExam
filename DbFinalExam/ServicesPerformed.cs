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
    public partial class ServicesPerformed : Form
    {
        public ServicesPerformed()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            comboBoxCustomer.BindQuery("select * from Customer", "CompanyName");
            comboBoxBusCon.BindQuery("select *,(FirstName + ' ' + LastName) as Name from Consultant c, TechnicalConsultant bc where bc.EmployeeID = c.EmployeeID",
                "Name");
            comboBoxServices.BindQuery(
                "select ServiceId, (CONVERT(varchar(10), ServiceId) + '-' + Description + ' $' + Convert(varchar(10),Cost)) as FullName from Service", "FullName");
            this.dataGridView1.BindQuery("select * from ServicesPerformed");
            this.dateTimePicker.Value = DateTime.Today;
            this.textBoxAmount.Text = "0";
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            dateTimePicker.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
            textBoxAmount.Text = row.Cells["Amount"].Value.ToString();
            textBoxServId.Text = row.Cells["ServicesPerformedID"].Value.ToString();
            comboBoxBusCon.SelectedItem =
                comboBoxBusCon.Items.Cast<DataRowView>().FirstOrDefault(p => p.GetDataRowValue("EmployeeID") == row.Cells["TechnicalConsultantID"].Value.ToString());
            comboBoxCustomer.SelectedItem = comboBoxCustomer.Items.Cast<DataRowView>().FirstOrDefault(p =>
                p.GetDataRowValue("CustomerID") == row.Cells["CustomerID"].Value.ToString());

            listBoxServices.Items.Clear();
            var services = Sql.Exe(p =>
                p.Query<Service>(
                    @"
select s.ServiceId, (CONVERT(varchar(10), s.ServiceId) + '-' + Description + ' $' + Convert(varchar(10),Cost)) as FullName 
from Service s, ServicesPerformedHasService ehs 
where s.ServiceId = ehs.ServiceID and ehs.ServicesPerformedID = @ServicesPerformedID",
                    new { ServicesPerformedID = row.Cells["ServicesPerformedID"].Value.ToString() }));

            foreach (var service in services)
            {
                listBoxServices.Items.Add(service);
            }

            listBoxLocations.Items.Clear();
            var locations = Sql.Exe(p => p.Query<Location>(@"
select *,(Street + ' ' + City + ', ' + State + ' ' + ZipCode) as Address 
from Location l, LocationHasServicesPerformed lsp
where lsp.LocationID = l.LocationID and l.CustomerID = lsp.CustomerID and lsp.ServicesPerformedID = @id",
new { id = row.Cells["ServicesPerformedID"].Value.ToString()}));
            foreach (var location in locations)
            {
                listBoxLocations.Items.Add(location);
            }

        }




        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Sql.Exe((p, t) =>
            {
                p.Execute("INSERT INTO [dbo].[ServicesPerformed] ([ServicesPerformedID] ,[Date] ,[Amount] ,[TechnicalConsultantID], CustomerID) VALUES (@ServicesPerformedId ,@Date ,@Amount ,@TechnicalConsultant, @CustomerID)",
                    new
                    {
                        ServicesPerformedId = textBoxServId.Text,
                        Date = dateTimePicker.Value,
                        Amount = textBoxAmount.Text,
                        TechnicalConsultant = comboBoxBusCon.SelectedItem.GetDataRowValue("EmployeeID"),
                        CustomerID = comboBoxCustomer.SelectedItem.GetDataRowValue("CustomerID")
                    }, t);

                foreach (Service item in listBoxServices.Items)
                {
                    p.Execute("insert into ServicesPerformedHasService(ServicesPerformedID, ServiceID) values (@ServicesPerformed,@Service)", new { ServicesPerformed = textBoxServId.Text, Service = item.ServiceID }, t);
                }

                foreach (Location location in listBoxLocations.Items)
                {
                    p.Execute("insert into LocationHasServicesPerformed(ServicesPerformedID,CustomerID,LocationID) VALUES (@ServicesPerformedID,@CustomerID,@LocationID)", new { ServicesPerformedID = textBoxServId.Text, CustomerID = location.CustomerId, LocationID = location.LocationId },t);
                }
            });

            Refresh();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            Sql.Exe((p, t) =>
            {
                p.Execute(@"
UPDATE [dbo].[ServicesPerformed] 
set [Date] = @Date,[Amount] = @Amount,[TechnicalConsultantID] = @TechnicalConsultant, [CustomerID] = @CustomerID 
where ServicesPerformedId = @ServicesPerformedId 
",
                    new
                    {
                        ServicesPerformedId = textBoxServId.Text,
                        Date = dateTimePicker.Value,
                        Amount = textBoxAmount.Text,
                        TechnicalConsultant = comboBoxBusCon.SelectedItem.GetDataRowValue("EmployeeID"),
                        CustomerID = comboBoxCustomer.SelectedItem.GetDataRowValue("CustomerID")
                    }, t);
            });
            Refresh();
        }
        private void ServicesPerformed_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            if (comboBoxServices.SelectedItem is DataRowView view)
            {
                listBoxServices.Items.Add(comboBoxServices.SelectedItem.DataRowViewToObject<Service>());
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Sql.Exe((p, t) =>
            {
                p.Execute("delete LocationHasServicesPerformed where ServicesPerformedId = @id", new { id = textBoxServId.Text }, t);
                p.Execute("delete ServicesPerformedHasService where ServicesPerformedId = @id", new { id = textBoxServId.Text }, t);
                p.Execute("delete ServicesPerformed where ServicesPerformedID = @id", new { id = textBoxServId.Text }, t);
            });
            Refresh();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            Refresh();
        }

        private void ComboBoxCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedItem is DataRowView)
                comboBoxCustLocations.BindQuery($"select *,(Street + ' ' + City + ', ' + State + ' ' + ZipCode) as Address from Location where CustomerID = {comboBoxCustomer.SelectedItem.GetDataRowValue("CustomerID")}", "Address");
        }

        private void ButtonAddLoc_Click(object sender, EventArgs e)
        {
            if (comboBoxCustLocations.SelectedItem is DataRowView)
            {
                listBoxLocations.Items.Add(comboBoxCustLocations.SelectedItem.DataRowViewToObject<Location>());
            }
        }
    }

  
}
