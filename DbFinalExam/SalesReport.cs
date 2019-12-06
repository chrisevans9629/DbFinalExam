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
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerTo.Value = DateTime.Now;
            Generate();
        }

        void Generate()
        {
            dataGridView1.BindQuery(@"
select c.CompanyName, (co.FirstName + ' ' + co.LastName) as TechnicalConsultant, sp.Date, Sum(sp.Amount) as Sales, Sum(s.Cost) as Cost, Sum(sp.Amount - s.Cost) as Profit
from ServicesPerformed sp left outer join 
Customer c on sp.CustomerID = c.CustomerID left outer join
Consultant co on sp.TechnicalConsultantID = co.EmployeeID left outer join
ServicesPerformedHasService sps on sps.ServicesPerformedID = sp.ServicesPerformedID left outer join
Service s on s.ServiceID = sps.ServiceID
where Date >= @From and Date < @To
group by c.CompanyName, co.FirstName, co.LastName, sp.Date", new { From = dateTimePickerFrom.Value, To=dateTimePickerTo.Value});



            var salesSql = @"
select Sum(sp.Amount) as Sales, Sum(s.Cost) as Cost, Sum(sp.Amount - s.Cost) as Profit
from ServicesPerformed sp left outer join 
ServicesPerformedHasService sps on sps.ServicesPerformedID = sp.ServicesPerformedID left outer join
Service s on s.ServiceID = sps.ServiceID
where Date >= @From and Date < @To";

            labelSales.BindQuery(salesSql, new { From = dateTimePickerFrom.Value, To = dateTimePickerTo.Value }, "Sales");

            labelSales.Text = "Sales: $" + labelSales.Text;

            labelCost.BindQuery(salesSql, new { From = dateTimePickerFrom.Value, To = dateTimePickerTo.Value }, "Cost");
            labelCost.Text = "Cost: $" + labelCost.Text;
            labelProfit.BindQuery(salesSql, new { From = dateTimePickerFrom.Value, To = dateTimePickerTo.Value }, "Profit");
            labelProfit.Text = "Profit $" + labelProfit.Text;

            var estimateSql = @"
select Sum(sp.Amount) as Sales, Sum(s.Cost) as Cost, Sum(sp.Amount - s.Cost) as Profit
from Estimate sp left outer join 
EstimateHasService sps on sps.EstimateID = sp.EstimateID left outer join
Service s on s.ServiceID = sps.ServiceID
where Date >= @From and Date < @To";

            labelEstimates.BindQuery(estimateSql, new { From = dateTimePickerFrom.Value, To = dateTimePickerTo.Value }, "Sales");
            labelEstimates.Text = "Estimated Sales: $" + labelEstimates.Text;

            labelEstCost.BindQuery(estimateSql, new { From = dateTimePickerFrom.Value, To = dateTimePickerTo.Value }, "Cost");
            labelEstCost.Text = "Estimated Cost: $" + labelEstCost.Text;

            labelEstProfit.BindQuery(estimateSql, new { From = dateTimePickerFrom.Value, To = dateTimePickerTo.Value }, "Profit");
            labelEstProfit.Text = "Estimated Profit: $" + labelEstProfit.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void SplitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
