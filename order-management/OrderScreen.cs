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
    public partial class OrderScreen : Form
    {
        public OrderScreen()
        {
            InitializeComponent();
        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            AddOrderScreen form = new AddOrderScreen();
            form.Show();
        }
    }
}
