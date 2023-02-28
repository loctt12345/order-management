using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order_management
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderScreen form = new OrderScreen();
            form.Show();
        }

        private void btnChef_Click(object sender, EventArgs e)
        {
            Chef_Display form = new Chef_Display();
            form.Show();
        }

        private void btnProfit_Click(object sender, EventArgs e)
        {
            ProfitReport form = new ProfitReport();
            form.Show();
        }
    }
}
