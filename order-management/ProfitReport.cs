using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting;
using Repository.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace order_management
{
    public partial class ProfitReport : Form
    {
        private PrimaryOrderService primaryOrderService = new PrimaryOrderService();
        public ProfitReport()
        {
            InitializeComponent();
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            //reset
            reportViewer1.Reset();
            //datasource
            DataTable dt = GetDataToReport(dateTimePicker1.Value,dateTimePicker2.Value);
            ReportDataSource ds = new ReportDataSource("ProfitReportView", dt);
            reportViewer1.LocalReport.DataSources.Add(ds);
            //path
            reportViewer1.LocalReport.ReportPath = "C:\\Disk D\\Desktop\\MAJOR\\SEMESTER_5\\PRN211\\order-management\\order-management\\ProfitReportView.rdlc";
            //Refresh
            reportViewer1.RefreshReport();
        }
        private DataTable GetDataToReport(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            DataColumn column = new DataColumn();
            DataRow row;
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Day";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Amount";
            dt.Columns.Add(column);
            primaryOrderService.GetAll().DistinctBy(x => x.OrderDate).Where(x => x.OrderDate >= From).Where(x => x.OrderDate <= To).Where(x => x.Status == 3).ToList().ForEach(x =>
            {
                row = dt.NewRow();
                row["Day"] = x.OrderDate;
                row["Amount"] = primaryOrderService.GetAll().Where(i => i.OrderDate == x.OrderDate).Where(x => x.Status == 3).Sum(i => i.Total);
                dt.Rows.Add(row);
            });
            dataGridView1.DataSource = dt;
            return dt;
        }
    }
}
