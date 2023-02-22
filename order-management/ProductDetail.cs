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
        private DataTable orderDetailsTB = null;
        private PrimaryOrder order = null;

        public ProductDetail(Product product, PrimaryOrder order, 
            DataTable orderDetailsTB, OrderDetail previousOrderDetail)
        {
            this.product = product;
            this.orderDetailsTB = orderDetailsTB;
            this.order = order;
            
            InitializeComponent();

            lbProductName.Text = product.ProductName;
            lbPrice.Text = product.Price.ToString();
            if (previousOrderDetail != null)
            {
                txtQuantity.Value = previousOrderDetail.Quantity;
                txtNote.Text = previousOrderDetail.Note;
            }
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
           

            this.orderDetailsTB.Rows.Add(this.product.ProductId,
                                        this.product.ProductName,
                                        orderDetail.Quantity,
                                        this.product.Price,
                                        orderDetail.Amount,
                                        orderDetail.Note);

            this.Close();
            
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
