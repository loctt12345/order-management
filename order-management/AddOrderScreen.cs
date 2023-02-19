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
using order_management.Models;

namespace order_management
{
    public partial class AddOrderScreen : Form
    {

        private List<Product> ProductDB = new List<Product>
            {
                new Product{ProductId= new Guid{},ProductName="a",Price=2000,Status=true},
                new Product{ProductId= new Guid{},ProductName="b",Price=2000,Status=true},
                new Product{ProductId= new Guid{},ProductName="c",Price=2000,Status=true},
                new Product{ProductId= new Guid{},ProductName="d",Price=2000,Status=true},
            };
        public AddOrderScreen()
        {
            
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Product Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Price", typeof(double)));

            for (int i = 0; i < this.ProductDB.Count; ++i)
            {
                dt.Rows.Add(this.ProductDB[i].ProductName,
                            this.ProductDB[i].Price);
            }
            dgvProducts.DataSource = dt;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Select";
            btn.HeaderText = "Select";
            btn.ReadOnly = false;
            dgvProducts.Columns.Add(btn);
            dgvProducts.AllowUserToAddRows = false;
        }


        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex >= 0 &&
                senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                ProductDetail form = new ProductDetail(this.ProductDB[e.RowIndex]);
                form.Show();
            }
        }
    }
}
