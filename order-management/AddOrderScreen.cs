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
        private DataGridView dgvOrder = null;

        public AddOrderScreen(PrimaryOrder order, DataGridView dgvOrder)
        {
            
            InitializeComponent();

            // set currentOrder
            this.currentOrder = order;
            this.dgvOrder = dgvOrder;

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
            DataTable dt1 = new DataTable();
            dt1.Columns.Add(new DataColumn("ProductId", typeof(String)));
            dt1.Columns.Add(new DataColumn("Product Name", typeof(String)));
            dt1.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt1.Columns.Add(new DataColumn("Price", typeof(double)));
            dt1.Columns.Add(new DataColumn("Amount", typeof(double)));
            dt1.Columns.Add(new DataColumn("Note", typeof(String)));

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "Select";
            btn1.HeaderText = "Select";
            btn1.ReadOnly = false;

            dgvCurrentOrder.DataSource = dt1;
            dgvCurrentOrder.Columns.Add(btn1);

            dgvCurrentOrder.Columns["ProductId"].Visible = false;
            dgvCurrentOrder.AllowUserToAddRows = false;
            dgvCurrentOrder.ReadOnly = false;
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
                ProductDetail form = new ProductDetail(product, this.currentOrder, dgvCurrentOrder);
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
                dgvCurrentOrder.Rows.RemoveAt(e.RowIndex);
                //Remove in order details list
                foreach(OrderDetail orderDetail in this.currentOrder.OrderDetails)
                {
                    if (orderDetail.ProductId.ToString().Equals(productId))
                    {
                        this.currentOrder.OrderDetails.Remove(orderDetail);
                        break;
                    }
                }

                // Create new form 
                ProductDetail form = new ProductDetail(product, this.currentOrder, dgvCurrentOrder);
                form.Show();
            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            // Get total
            double total = 0;
            foreach (OrderDetail orderDetail in this.currentOrder.OrderDetails)
            {
                total += orderDetail.Amount;
            }
            this.currentOrder.Total = total;
            this.currentOrder.Status = 1;
            this._orderService.Create(currentOrder);

            this.dgvOrder.DataSource = this._orderService.GetAll();

            this.Close();
        }
    }
}
