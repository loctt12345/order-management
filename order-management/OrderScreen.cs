using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository.Models;
using Repository.Services;

namespace order_management
{
    public partial class OrderScreen : Form
    {
        private OrderService _orderService = new OrderService();

        public OrderScreen()
        {
            InitializeComponent();
            dgvOrder.DataSource = this._orderService.GetAll();
        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            PrimaryOrder order = new PrimaryOrder
            {
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                Total = 0,
                Status = 0
            };

            
            AddOrderScreen form = new AddOrderScreen(order);
            form.Show();
        }
    }
}
