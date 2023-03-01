using Repository.Entity;
using Repository.Models;
using Repository.Services;

namespace order_management
{
    public partial class Chef_Display : Form
    {
        OrderDetailService service = new OrderDetailService();
        ProductService productService = new ProductService();

        public Chef_Display()
        {

            InitializeComponent();
            dgvShowData.DataSource = getChefDetails();

            dgvShowData.AutoGenerateColumns = true;
            dgvShowData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvShowData.Columns[0].HeaderCell.Value = "Order ID";
            dgvShowData.Columns[0].Width = 50;
            dgvShowData.Columns[1].Width = 100;
            dgvShowData.Columns[2].Width = 100;
            dgvShowData.Columns[3].Width = 100;
            dgvShowData.Columns[4].Width = 500;
        }

        protected List<OrderDetail> getHaventDoneList()
        {

            return service.GetAll().Where(x => x.Status == false).OrderBy(x => x.OrderDate).ToList();
        }


        //Create a New Entity - dont have in database, Which can Show Product Name
        protected List<ChefDetails> getChefDetails()
        {
            var listOrderDetails = getHaventDoneList();
            var listChefDetails = new List<ChefDetails>();
            for (int i = 0; i < listOrderDetails.Count; i++)
            {
                ChefDetails details = new ChefDetails();
                details.OrderDetailsId = listOrderDetails[i].OrderDetailsId;
                details.ProductName = productService.GetById(listOrderDetails[i].ProductId).ProductName;
                details.Quantity = listOrderDetails[i].Quantity;
                details.OrderDate = listOrderDetails[i].OrderDate;
                details.Note = listOrderDetails[i].Note;

                listChefDetails.Add(details);
            }

            return listChefDetails;
        }


        protected void updateStatus(Guid id)
        {
            /*    var listOrderDetails = getHaventDoneList();
                for (int i = 0; i < listOrderDetails.Count; i++)
                {
                    if (id == listOrderDetails[i].OrderDetailsId)
                    {
                        listOrderDetails[i].Status = true;

                        service.Update(listOrderDetails[i]);
                        break;
                    }
                }*/

            var item = service.GetById(id);
            if (item != null)
            {
                item.Status = true;
                service.Update(item);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvShowData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow viewRows in dgvShowData.SelectedRows)
                {
                    Guid id = (Guid)viewRows.Cells[0].Value;
                    updateStatus(id);
                }
                dgvShowData.DataSource = getChefDetails();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            service = new OrderDetailService();
            dgvShowData.DataSource = getChefDetails();
        }

    }
}