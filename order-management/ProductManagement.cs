using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository;
using Repository.Models;
using Repository.Services;
using System;
using System.Data;
using System.Resources;
using System.Windows.Forms;


namespace order_management
{
    public partial class ProductManagement : Form
    {
        RepositoryBase<Product> productRepo = new RepositoryBase<Product>();
        ProductService productService = new ProductService();
        public ProductManagement()
        {
            InitializeComponent();
            var products = productRepo.GetAll()
                    .Where(p => p.Status == true)
                    .ToList();
            products.Sort();
            dgvProductList.DataSource = products;
            dgvProductList.Columns[0].Visible = false;
            dgvProductList.Columns[4].Visible = false;
            dgvProductList.Columns[5].Visible = false;
            dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProductList.Visible = true;
                //dgvProductList.Columns[3].Visible = false;
                //dgvProductList.ScrollBars = ScrollBars.None;
                var products = productRepo.GetAll()
                    .Where(p => p.Status == true)
                    .ToList();
                products.Sort();
                dgvProductList.DataSource = products;
                dgvProductList.Columns[0].Visible = false;
                dgvProductList.Columns[4].Visible = false;
                dgvProductList.Columns[5].Visible = false;
                dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot show all data right now");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvProductList.Columns[3].Visible = false;


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
                MessageBox.Show("Added Sucessful");
                btnShowAll.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Add New Product");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dg = MessageBox.Show("Exit Now?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dg == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Exit Now, try again");
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
                if (dgvProductList.Rows.Count == 0)
                {
                    MessageBox.Show("There are no product to update");
                }
                else
                {
                    //dgvProductList.Columns[3].Visible = false;
                    foreach (Product product in updatedProducts)
                    {
                        productRepo.Update(product);
                    }
                    MessageBox.Show("Update sucessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update right now, try again");
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvProductList.Columns[3].Visible = false;
                if (dgvProductList.Rows.Count == 0)
                {
                    MessageBox.Show("There are no products to delete");
                }
                else if (dgvProductList.CurrentRow != null)
                {
                    DataGridViewRow dgvRow = dgvProductList.CurrentRow;
                    Guid ProductId = new Guid(dgvRow.Cells[0].Value.ToString());
                    List<Product> product = productService.GetAll().Where(x => x.ProductId == ProductId).ToList();
                    product[0].Status = false;
                    DialogResult dg = MessageBox.Show("Are you sure delete this product ?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dg == DialogResult.OK)
                    {
                        // Refresh the DataGridView to show the updated list of products
                        dgvProductList.DataSource = productService.GetAll()
                            .Where(p => p.Status == true);
                        MessageBox.Show("Delete Sucessful");
                        btnShowAll.PerformClick();
                    }
                    if (dg == DialogResult.Cancel)
                    {
                        MessageBox.Show("There are no products to delete");
                    }
                    productService.Update(product[0]);
                    btnShowAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Delete, check again product");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProductList.Columns[4].Visible = false;
                //dgvProductList.Columns[3].Visible = false;
                string keyword = txtSearch.Text;
                var productService = new ProductService();
                var product = productService.Search(keyword);
                dgvProductList.DataSource = product;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Maybe do not have product you need");
            }
        }

    }
}