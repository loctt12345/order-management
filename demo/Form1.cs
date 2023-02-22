using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository.Models;
using Repository.Services;
using System;
using System.Data;
using System.Resources;
using System.Windows.Forms;


namespace demo
{
    public partial class screen_Winform : Form
    {
        RepositoryBase<Product> productRepo = new RepositoryBase<Product>();
        ProductService productService = new ProductService();
        public screen_Winform()
        {
            InitializeComponent();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProductList.Visible = true;
               
                var products = productRepo.GetAll()
                    .Where(p=> p.Status == true)
                    .ToList();
                dgvProductList.DataSource = products;
                dgvProductList.Columns[4].Visible= false;
            } catch(Exception ex)
            {
                MessageBox.Show("Cannot show all data right now");
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try {
                var product = new Product();
                product.ProductId = Guid.NewGuid();
                product.ProductName = txtProductName.Text;
                product.Price = double.Parse(txtProductPrice.Text);
                if (checkedYes.Checked)
                {
                    product.Status = true;
                }
                else
                {
                    product.Status = false;
                }

                productRepo.Create(product);
                MessageBox.Show("Added Sucessful, Please click show all to refresh");
                
            }
            catch(Exception ex) {
                MessageBox.Show("Cannot Add New Product");
                Console.WriteLine(ex.Message);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dg = MessageBox.Show("Exit Now?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dg == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Exit Now, try again");
                Console.WriteLine(ex.Message);
            }
        }

        private List<Product> updatedProducts = new List<Product>();

        private void dgvProductList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductList.CurrentRow != null)
            {
                DataGridViewRow dgvRow = dgvProductList.CurrentRow;
                Product product = new Product()
                {
                    ProductId = new Guid(dgvRow.Cells[0].Value.ToString()),
                    ProductName = dgvRow.Cells[1].Value.ToString(),
                    Price = Convert.ToDouble(dgvRow.Cells[2].Value),
                    Status = Convert.ToBoolean(dgvRow.Cells[3].Value)
                };
                updatedProducts.Add(product);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Product product in updatedProducts)
                {
                    productRepo.Update(product);
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update sucessful");
                Console.WriteLine(ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductList.CurrentRow != null)
                {
                    DataGridViewRow dgvRow = dgvProductList.CurrentRow;
                    Guid ProductId = new Guid(dgvRow.Cells[0].Value.ToString());
                    List<Product> product = productService.GetAll().Where(x => x.ProductId == ProductId).ToList();
                    product[0].Status = false;
                    productService.Update(product[0]);
                }

                // Refresh the DataGridView to show the updated list of products
                dgvProductList.DataSource = productService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text;              
                var productService = new ProductService();
                var product = productService.Search(keyword);
                dgvProductList.DataSource = product;
                MessageBox.Show("Search Sucessful");
            } catch(Exception ex )
            {
                MessageBox.Show("Maybe do not have product you need");
                Console.WriteLine(ex.Message);
            }
        }
    }
}