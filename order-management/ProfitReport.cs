
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.Json;
using Repository.Models;
using System.Drawing.Text;

namespace order_management
{
    public partial class ProfitReport : Form
    {
        private PrimaryOrderService primaryOrderService = new PrimaryOrderService();
        private Chart resultChart = new Chart();
        public ProfitReport()
        {
            InitializeComponent();
            DataTable dt = primaryOrderService.GetDataToReport(DateTime.Today.AddYears(-1), DateTime.Today);
            dgvReport.ScrollBars = ScrollBars.None;
            InitChart(dt);
            ModifyChartTitle(DateTime.Today.AddYears(-1), DateTime.Today);
            MapDataToChart(dt);

        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {

            var fromDate = dateTimePicker1.Value;
            var toDate = dateTimePicker2.Value;
            var timeSpan = new TimeSpan(366, 0, 0, 0, 0);
            if (toDate.Subtract(fromDate) > timeSpan)
            {
                dgvReport.Hide();
                resultChart.Hide();
                MessageBox.Show("Cannot display a chart with a range over 1 year");
                return;
            }
            DataTable dt = primaryOrderService.GetDataToReport(fromDate, toDate);
            InitChart(dt);
            ModifyChartTitle(fromDate, toDate);
            MapDataToChart(dt);
        }
        private void MapDataToChart(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    resultChart.Series[0].Points.AddXY(row[0], row[1]);
                    resultChart.Series[0].Points[i].Label = row[1].ToString();
                    i++;
                }
            }
            else
            {
                dgvReport.Hide();
                resultChart.Hide();
                MessageBox.Show("No data found.");
                return;
            }
            dgvReport.DataSource = dt;
        }
        private void InitChart(DataTable dt)
        {
            if (this.Controls.Contains(resultChart))
            {
                this.Controls.Remove(resultChart);
            }
            resultChart = new Chart();
            this.Controls.Add(resultChart);
            resultChart.Titles.Add("");
            resultChart.Titles[0].Font = new Font("Arial", 18, FontStyle.Bold);
            resultChart.Titles[0].ForeColor = Color.SteelBlue;
            resultChart.Size = new Size(1030, 715);
            resultChart.Location = new Point(359, 137);
            resultChart.Legends.Add("Legend1");
            resultChart.ChartAreas.Add("ChartArea1");
            Series seriesTotal = new Series("Total");
            seriesTotal.XValueType = ChartValueType.Auto;
            seriesTotal.YValueType = ChartValueType.Double;
            seriesTotal.Color = Color.LightSteelBlue;
            seriesTotal.ChartType = SeriesChartType.Column;
            seriesTotal.LabelForeColor = Color.OrangeRed;
            seriesTotal.BorderWidth = 2;
            seriesTotal.Font = new Font("Arial", 7, FontStyle.Bold);
            seriesTotal.IsXValueIndexed = true;
            resultChart.Series.Add(seriesTotal);
            resultChart.ChartAreas[0].AxisX.Title = dt.Columns[0].ColumnName;
            resultChart.ChartAreas[0].AxisY.Title = "Total";
            resultChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            resultChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
            resultChart.Click += new EventHandler(resultChart_Click);
            dgvReport.Show();
        }
        private void resultChart_Click(object sender, EventArgs e)
        {
            // Get the mouse coordinates relative to the chart control
            Point mousePoint = resultChart.PointToClient(MousePosition);

            // Perform a hit test to get the chart element that was clicked
            HitTestResult result = resultChart.HitTest(mousePoint.X, mousePoint.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;
                string[] targetData = resultChart.Series[0].Points[index].AxisLabel.Trim().Split('/', '-');
                HandleClickToSeeDetailsChart(targetData);
            }
        }
        private void ModifyChartTitle(DateTime fromDate, DateTime toDate)
        {
            resultChart.Titles[0].Text = $"Profit From {fromDate.ToShortDateString()} To {toDate.ToShortDateString()}";
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow row = dgvReport.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

                string[] targetData = cell.Value.ToString().Trim().Split('/', '-');
                HandleClickToSeeDetailsChart(targetData);
            }
        }
        private void HandleClickToSeeDetailsChart(string[] targetData)
        {
            DataTable dt = new DataTable();
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();
            switch (targetData.Length)
            {
                //if chart is showed by months
                case 2:
                    fromDate = new DateTime(Int32.Parse(targetData[1]), Int32.Parse(targetData[0]), 1);
                    toDate = fromDate.AddMonths(1).AddDays(-1);
                    break;
                //if chart is showed by months, click first/last column
                case 4:
                    fromDate = new DateTime(Int32.Parse(targetData[3]), Int32.Parse(targetData[2]), Int32.Parse(targetData[0]));
                    toDate = new DateTime(fromDate.Year, fromDate.Month, Int32.Parse(targetData[1]));
                    break;
                //if chart is showed by weeks
                case 5:
                    fromDate = new DateTime(Int32.Parse(targetData[4]), Int32.Parse(targetData[1]), Int32.Parse(targetData[0]));
                    toDate = fromDate.AddDays(7);
                    break;
                default:
                    return;
            }

            dt = primaryOrderService.GetDataToReport(fromDate, toDate);
            InitChart(dt);
            ModifyChartTitle(fromDate, toDate);
            MapDataToChart(dt);
        }
    }
}
