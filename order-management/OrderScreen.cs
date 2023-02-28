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
        private EmployeeService _employeeService = new EmployeeService();
        private DataTable orderTable = new DataTable();
        private OrderDetailService _orderDetailService = new OrderDetailService();

        public OrderScreen()
        {
            InitializeComponent();

            orderTable.Columns.Add("OrderId", typeof(Guid));
            orderTable.Columns.Add("EmployeeId", typeof(Guid));
            orderTable.Columns.Add("Date", typeof(DateTime));
            orderTable.Columns.Add("Total", typeof(double));
            orderTable.Columns.Add("Status", typeof(int));
            var list = this._orderService.GetAll();
            foreach (PrimaryOrder order in list)
            {
                orderTable.Rows.Add(order.OrderId, order.EmployeeId, 
                    order.OrderDate, order.Total, order.Status);
            }
            orderTable.DefaultView.Sort = "Date DESC";
            dgvOrder.DataSource = orderTable;
            dgvOrder.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrder.ReadOnly = true;
            dgvOrder.AllowUserToAddRows = false;
            orderTable.AcceptChanges();
        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            PrimaryOrder order = new PrimaryOrder
            {
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                Total = 0,
                Status = 0,
                EmployeeId = Guid.Parse("76CE881A-72E5-4C75-9C54-58D7A016BDFF"),
                OrderDetails = new List<OrderDetail>()
            };

            
            AddOrderScreen form = new AddOrderScreen(order, this.orderTable);
            form.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Guid orderId = Guid.Parse(txtOrderID.Text);
                PrimaryOrder order = _orderService.GetById(orderId);
                order.OrderDetails = _orderDetailService.GetByOrderId(orderId);
                txtOrderID.Text = "";
                AddOrderScreen form = new AddOrderScreen(order, this.orderTable);
                form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid order id or order is not existed!!!", "Error", MessageBoxButtons.OK);
            }
        }

        private void dgvOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            Guid orderId = Guid.Parse(dgvOrder.Rows[e.RowIndex].Cells["OrderId"].Value.ToString());
            PrimaryOrder order = _orderService.GetById(orderId);
            order.OrderDetails = _orderDetailService.GetByOrderId(orderId);
            AddOrderScreen form = new AddOrderScreen(order, this.orderTable);
            form.Show();
        }
    }
}