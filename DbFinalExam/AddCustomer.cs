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
            loc.Add(new Location()
            {
                BuildingSize = int.Parse(textBoxLocSize.Text),
                City = textBoxLocCity.Text,
                CustomerId = int.Parse(textBoxCustomerId.Text),
                LocationId = int.Parse(textBoxLocId.Text),
                Street = textBoxLocStrt.Text,
                Telephone = textBoxLocTel.Text,
                ZipCode = textBoxLocZip.Text
            });
            Locations = loc;
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
