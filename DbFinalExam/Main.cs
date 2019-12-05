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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sales = new SalesReport();
            sales.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var addCust = new AddCustomer();
            addCust.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var addCust = new AddEstimate();
            addCust.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var services = new ServicesPerformed();
            services.ShowDialog();
        }
    }
}
