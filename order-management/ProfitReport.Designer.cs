namespace order_management
{
    partial class ProfitReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnShowReport = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dgvReport = new DataGridView();
            screenLayout = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            labelNote2 = new Label();
            ProfitReportLabel = new Label();
            labelNote1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            screenLayout.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnShowReport
            // 
            btnShowReport.Location = new Point(277, 51);
            btnShowReport.Margin = new Padding(3, 10, 3, 3);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new Size(74, 27);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Show";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(3, 51);
            dateTimePicker1.Margin = new Padding(3, 10, 3, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(128, 27);
            dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(140, 51);
            dateTimePicker2.Margin = new Padding(3, 10, 3, 3);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(128, 27);
            dateTimePicker2.TabIndex = 2;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.BackgroundColor = SystemColors.Control;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(31, 161);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.RowTemplate.Height = 29;
            dgvReport.Size = new Size(281, 676);
            dgvReport.TabIndex = 3;
            dgvReport.CellClick += dgvReport_CellClick;
            // 
            // screenLayout
            // 
            screenLayout.ColumnCount = 5;
            screenLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            screenLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            screenLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            screenLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74F));
            screenLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            screenLayout.Controls.Add(dgvReport, 1, 2);
            screenLayout.Controls.Add(tableLayoutPanel2, 3, 1);
            screenLayout.Controls.Add(ProfitReportLabel, 0, 0);
            screenLayout.Controls.Add(labelNote1, 1, 1);
            screenLayout.Dock = DockStyle.Fill;
            screenLayout.Location = new Point(0, 0);
            screenLayout.Name = "screenLayout";
            screenLayout.RowCount = 4;
            screenLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            screenLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            screenLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 77F));
            screenLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            screenLayout.Size = new Size(1435, 886);
            screenLayout.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(btnShowReport, 2, 1);
            tableLayoutPanel2.Controls.Add(dateTimePicker2, 1, 1);
            tableLayoutPanel2.Controls.Add(dateTimePicker1, 0, 1);
            tableLayoutPanel2.Controls.Add(labelNote2, 3, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(346, 73);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1055, 82);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label1, 3);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Arial", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0, 0, 3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 8, 5, 5);
            label1.Size = new Size(408, 41);
            label1.TabIndex = 6;
            label1.Text = "Select a range to show report: ";
            // 
            // labelNote2
            // 
            labelNote2.AutoSize = true;
            labelNote2.Dock = DockStyle.Bottom;
            labelNote2.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            labelNote2.Location = new Point(416, 61);
            labelNote2.Margin = new Padding(5);
            labelNote2.Name = "labelNote2";
            labelNote2.Size = new Size(634, 16);
            labelNote2.TabIndex = 3;
            labelNote2.Text = "*Click column on chart to see details";
            labelNote2.TextAlign = ContentAlignment.BottomRight;
            // 
            // ProfitReportLabel
            // 
            ProfitReportLabel.AutoSize = true;
            ProfitReportLabel.BackColor = Color.SteelBlue;
            screenLayout.SetColumnSpan(ProfitReportLabel, 5);
            ProfitReportLabel.Dock = DockStyle.Fill;
            ProfitReportLabel.Font = new Font("Arial", 25F, FontStyle.Bold, GraphicsUnit.Point);
            ProfitReportLabel.ForeColor = SystemColors.Control;
            ProfitReportLabel.Location = new Point(0, 0);
            ProfitReportLabel.Margin = new Padding(0);
            ProfitReportLabel.Name = "ProfitReportLabel";
            ProfitReportLabel.Padding = new Padding(15, 12, 0, 10);
            ProfitReportLabel.Size = new Size(1435, 70);
            ProfitReportLabel.TabIndex = 4;
            ProfitReportLabel.Text = "Profit Report Management";
            // 
            // labelNote1
            // 
            labelNote1.AutoSize = true;
            labelNote1.Dock = DockStyle.Bottom;
            labelNote1.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            labelNote1.Location = new Point(33, 137);
            labelNote1.Margin = new Padding(5);
            labelNote1.Name = "labelNote1";
            labelNote1.Size = new Size(277, 16);
            labelNote1.TabIndex = 7;
            labelNote1.Text = "*Click range to see details";
            labelNote1.TextAlign = ContentAlignment.BottomRight;
            // 
            // ProfitReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 886);
            Controls.Add(screenLayout);
            Name = "ProfitReport";
            Text = "ProfitReport";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            screenLayout.ResumeLayout(false);
            screenLayout.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnShowReport;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridView dgvReport;
        private TableLayoutPanel screenLayout;
        private TableLayoutPanel tableLayoutPanel2;
        private Label ProfitReportLabel;
        private Label label1;
        private Label labelNote2;
        private Label labelNote1;
    }
}