using Repository.Services;

namespace order_management
{
    public partial class Profit_Report : Form
    {
        EmployeeService employeeService= new EmployeeService();
        public Profit_Report()
        {
            InitializeComponent();
            var listEmployee = employeeService.GetAll();
            dgvDemo.DataSource = listEmployee;
        }
    }
}