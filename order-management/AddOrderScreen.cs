using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Repository;
using Repository.Models;
using Repository.Services;

namespace order_management
{
    public partial class AddOrderScreen : Form
    {
        private ProductService _productService = new ProductService();
        private OrderService _orderService = new OrderService();
        private PrimaryOrder currentOrder = null;
        private DataTable orderTable = null;
        private DataTable dt1 = new DataTable();
        private OrderDetailService _orderDetailService = new OrderDetailService();

        public AddOrderScreen(PrimaryOrder order,  DataTable orderTable)
        {
            
            InitializeComponent();

            // set currentOrder
            this.currentOrder = order;
            this.orderTable = orderTable;

            //Create table with 3 columns
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new DataColumn("Product Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Price", typeof(double)));
            
            //Get from DB 
            List<Product> ProductDB = this._productService.GetAll();


            //Add rows to table
            for (int i = 0; i < ProductDB.Count; ++i)
            {
                dt.Rows.Add(ProductDB[i].ProductId,
                            ProductDB[i].ProductName,
                            ProductDB[i].Price);
            }

            //Add button column - Button to choose to add product
            dgvProducts.DataSource = dt;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Select";
            btn.HeaderText = "Select";
            btn.ReadOnly = false;
            dgvProducts.Columns.Add(btn);

            // invisible productId column and disable user to add new rows
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.Columns["ProductId"].Visible = false;
            dgvProducts.ReadOnly = false;

            // Create order details table
            dt1.Columns.Add(new DataColumn("ProductId", typeof(String)));
            dt1.Columns.Add(new DataColumn("Product Name", typeof(String)));
            dt1.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt1.Columns.Add(new DataColumn("Price", typeof(double)));
            dt1.Columns.Add(new DataColumn("Amount", typeof(double)));
            dt1.Columns.Add(new DataColumn("Note", typeof(String)));

            foreach (OrderDetail orderDetail in this.currentOrder.OrderDetails)
            {
                Product product = _productService.GetById(orderDetail.ProductId);
                this.dt1.Rows.Add(orderDetail.ProductId,
                                       product.ProductName,
                                       orderDetail.Quantity,
                                       product.Price,
                                       orderDetail.Amount,
                                       orderDetail.Note);

            }

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "Select";
            btn1.HeaderText = "Select";
            btn1.ReadOnly = false;

            dgvCurrentOrder.DataSource = dt1;
            dgvCurrentOrder.Columns.Add(btn1);

            dgvCurrentOrder.Columns["ProductId"].Visible = false;
            dgvCurrentOrder.AllowUserToAddRows = false;
            dgvCurrentOrder.ReadOnly = true;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            //Check if user click button "select"
            if (e.ColumnIndex >= 0 &&
                senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Get hidden productId string
                String productId = senderGrid.Rows[e.RowIndex].Cells["ProductId"].Value.ToString();
                
                // Get product from DB by Id String
                Product product = this._productService.GetById(new Guid(productId));
                
                // Create new form 
                ProductDetail form = new ProductDetail(product, this.currentOrder, dt1, null);
                form.Show();
            }
        }

        private void dgvCurrentOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex >= 0 &&
                senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Get hidden productId string
                String productId = senderGrid.Rows[e.RowIndex].Cells["ProductId"].Value.ToString();

                // Get product from DB by Id String
                Product product = this._productService.GetById(new Guid(productId));

                // Delete old row
                this.dt1.Rows.RemoveAt(e.RowIndex);
                
                // Get order detail need to remove
                OrderDetail orderDetailNeedToRemove = this.currentOrder.OrderDetails
                    .Where(orderDetail => orderDetail.ProductId.ToString().Equals(productId))
                    .FirstOrDefault();

                //Remove in order details list
                this.currentOrder.OrderDetails.Remove(orderDetailNeedToRemove);

                // Create new form 
                ProductDetail form = new ProductDetail(product, this.currentOrder, dt1, orderDetailNeedToRemove);
                form.Show();
            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to submit the order ?", "Confirm" , MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Get total
                double total = 0;
                foreach (OrderDetail orderDetail in this.currentOrder.OrderDetails)
                {
                    total += orderDetail.Amount;
                }
                this.currentOrder.Total = total;

                if (this.currentOrder.Status == 0)
                {
                    this.currentOrder.Status = 1;
                    this._orderService.Create(currentOrder);
                    this.orderTable.Rows.Add(currentOrder.OrderId, currentOrder.EmployeeId,
                    currentOrder.OrderDate, currentOrder.Total, currentOrder.Status);
                }
                else
                {
                    this.currentOrder.OrderDate = DateTime.Now;
                    this.orderTable.Rows.Remove(this.orderTable.Select("OrderId='"
                        + this.currentOrder.OrderId.ToString() + "'")[0]);

                    this.orderTable.Rows.Add(currentOrder.OrderId, currentOrder.EmployeeId,
                    currentOrder.OrderDate, currentOrder.Total, currentOrder.Status);
                    this.orderTable.AcceptChanges();

                    this._orderService.Update(this.currentOrder);
                    this._orderDetailService.DeleteByOrderId(this.currentOrder.OrderId);

                    try
                    {
                        foreach (OrderDetail orderDetail1
                            in this.currentOrder.OrderDetails)
                        {
                            orderDetail1.Order = null;
                            this._orderDetailService.Create(orderDetail1);
                        }
                    }
                    catch(Exception)
                    {

                    }
                }

                this.Close();
            }
        }
    }
}
