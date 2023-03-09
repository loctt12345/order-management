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
            list.Sort();
            foreach (PrimaryOrder order in list)
            {
                DataRow row = orderTable.NewRow();
                row["OrderId"] = order.OrderId;
                row["EmployeeId"] = order.EmployeeId;
                row["Date"] = order.OrderDate;
                row["Total"] = order.Total;
                row["Status"] = order.Status;
                orderTable.Rows.Add(row);
            }
            dgvOrder.DataSource = orderTable;
            dgvOrder.Columns["EmployeeId"].Visible = false;
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvOrder.Columns["OrderId"].Visible = false;
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
            this.btnRefresh_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String orderId = txtOrderID.Text;
                List<PrimaryOrder> orderList = _orderService.GetByIdContains(orderId);
                txtOrderID.Text = "";
                orderTable = new DataTable();
                orderTable.Columns.Add("OrderId", typeof(Guid));
                orderTable.Columns.Add("EmployeeId", typeof(Guid));
                orderTable.Columns.Add("Date", typeof(DateTime));
                orderTable.Columns.Add("Total", typeof(double));
                orderTable.Columns.Add("Status", typeof(int));
                orderList.Sort();
                foreach (PrimaryOrder order in orderList)
                {
                    DataRow row = orderTable.NewRow();
                    row["OrderId"] = order.OrderId;
                    row["EmployeeId"] = order.EmployeeId;
                    row["Date"] = order.OrderDate.ToShortDateString();
                    row["Total"] = order.Total;
                    row["Status"] = order.Status;
                    orderTable.Rows.Add(row);
                }
                dgvOrder.DataSource = orderTable;
                dgvOrder.Columns["EmployeeId"].Visible = false;
                dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvOrder.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //dgvOrder.Columns["OrderId"].Visible = false;
                dgvOrder.ReadOnly = true;
                dgvOrder.AllowUserToAddRows = false;
                orderTable.AcceptChanges();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            orderTable = new DataTable();
            orderTable.Columns.Add("OrderId", typeof(Guid));
            orderTable.Columns.Add("EmployeeId", typeof(Guid));
            orderTable.Columns.Add("Date", typeof(DateTime));
            orderTable.Columns.Add("Total", typeof(double));
            orderTable.Columns.Add("Status", typeof(int));
            var list = this._orderService.GetAll();
            list.Sort();
            foreach (PrimaryOrder order in list)
            {
                DataRow row = orderTable.NewRow();
                row["OrderId"] = order.OrderId;
                row["EmployeeId"] = order.EmployeeId;
                row["Date"] = order.OrderDate;
                row["Total"] = order.Total;
                row["Status"] = order.Status;
                orderTable.Rows.Add(row);
            }
            dgvOrder.DataSource = orderTable;
            dgvOrder.Columns["EmployeeId"].Visible = false;
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvOrder.ReadOnly = true;
            dgvOrder.AllowUserToAddRows = false;
            orderTable.AcceptChanges();
        }
    }
}