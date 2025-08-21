using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechTopiaM2
{
    public partial class Sales_Summary : Form
    {
        public Sales_Summary()
        {
            InitializeComponent();
        }

        private void Sales_Summary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsTables.OrderbyDate' table. You can move, or remove it, as needed.
            this.orderbyDateTableAdapter.Fill(this.dsTables.OrderbyDate);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            orderbyDateTableAdapter.FillByDate(dsTables.OrderbyDate,
              dateTimePicker1.Value.Date.ToShortDateString());

        }
    }
}
