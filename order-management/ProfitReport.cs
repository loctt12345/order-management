
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Forms.DataVisualization.Charting;
namespace order_management
{
    public partial class ProfitReport : Form
    {
        private PrimaryOrderService primaryOrderService = new PrimaryOrderService();
        private Chart resultChart = new Chart();
        public ProfitReport()
        {
            InitializeComponent();

        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(resultChart))
            {
                this.Controls.Remove(resultChart);
            }
            resultChart = new Chart();
            this.Controls.Add(resultChart);
            resultChart.Size = new Size(946, 593);
            resultChart.Location = new Point(359, 137);
            resultChart.Titles.Add("Profit From " + dateTimePicker1.Value.ToShortDateString() + " To " + dateTimePicker2.Value.ToShortDateString());
            resultChart.Titles[0].Font = new Font("Arial", 18, FontStyle.Bold);
            resultChart.Titles[0].ForeColor = Color.SteelBlue;
            resultChart.Legends.Add("Legend1");
            resultChart.ChartAreas.Add("ChartArea1");
            DataTable dt = primaryOrderService.GetDataToReport(dateTimePicker1.Value, dateTimePicker2.Value);
            Series seriesTotal = new Series("Total");
            seriesTotal.XValueType = ChartValueType.DateTime;
            seriesTotal.YValueType = ChartValueType.Double;
            seriesTotal.Color = Color.LightGreen;
            seriesTotal.ChartType = SeriesChartType.Spline;
            seriesTotal.LabelForeColor = Color.OrangeRed;
            seriesTotal.BorderWidth = 2;
            seriesTotal.Font = new Font("Arial", 10, FontStyle.Regular);
            resultChart.Series.Add(seriesTotal);
            resultChart.ChartAreas[0].AxisX.Title = "Day";
            resultChart.ChartAreas[0].AxisY.Title = "Total";
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    seriesTotal.Points.AddXY(row[0], row[1]);
                    seriesTotal.Points[i].Label = row[1].ToString();
                    i++;
                }
            }
            else
            {
                MessageBox.Show("No data found.");
            }
            dgvReport.DataSource = dt;
        }
    }
}
