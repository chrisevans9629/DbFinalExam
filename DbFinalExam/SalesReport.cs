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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Generate();
        }
    }
}
