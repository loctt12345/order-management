using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using order_management.Models;

namespace order_management
{
    public partial class PreviewScreen : Form
    {
        public PreviewScreen(List<Product> ProductList, List<String> NoteList, List<int> QuantityList)
        {
            InitializeComponent();
            
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Product Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Price", typeof(double)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt.Columns.Add(new DataColumn("Note", typeof(String)));

            for (int i = 0; i < ProductList.Count; ++i)
            {
                dt.Rows.Add(ProductList[i].ProductName, ProductList[i].Price, QuantityList[i], NoteList[i]);
            }
            dgvProducts.DataSource = dt;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["AddOrderScreen"].Close();
        }
    }
}
