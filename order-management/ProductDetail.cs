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

namespace order_management
{
    public partial class ProductDetail : Form
    {
        private Product product = null;
        private DataGridView dgvOrder = null;
        private PrimaryOrder order = null;

        public ProductDetail(Product product, PrimaryOrder order, DataGridView dgvOrder)
        {
            this.product = product;
            this.dgvOrder = dgvOrder;
            this.order = order;

            InitializeComponent();

            lbProductName.Text = product.ProductName;
            lbPrice.Text = product.Price.ToString();
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                OrderDetailsId = Guid.NewGuid(),
                OrderId = this.order.OrderId,
                ProductId = this.product.ProductId,
                Quantity = int.Parse(txtQuantity.Text),
                Amount = int.Parse(txtQuantity.Text) * product.Price,
                Note = txtNote.Text,
                OrderDate = this.order.OrderDate,
                Order = this.order
            };

            order.OrderDetails.Add(orderDetail);
            

            DataTable dt = (DataTable)this.dgvOrder.DataSource;
            DataRow row = dt.NewRow();
            row["Product Name"] = this.product.ProductName;
            row["Quantity"]= orderDetail.Quantity;
            row["Price"] = this.product.Price;
            row["Amount"] = orderDetail.Amount;
            row["Note"] = orderDetail.Note;
            row["ProductId"] = orderDetail.ProductId;
            dt.Rows.Add(row);
            dt.AcceptChanges();

            this.Close();
            
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
