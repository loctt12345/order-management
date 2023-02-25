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
            ProfitReportLabel = new Label();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnShowReport
            // 
            btnShowReport.Location = new Point(665, 91);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new Size(94, 29);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Show";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(359, 93);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(130, 27);
            dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(513, 93);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(130, 27);
            dateTimePicker2.TabIndex = 2;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(39, 137);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.RowTemplate.Height = 29;
            dgvReport.Size = new Size(268, 715);
            dgvReport.TabIndex = 3;
            dgvReport.CellClick += dgvReport_CellClick;
            // 
            // ProfitReportLabel
            // 
            ProfitReportLabel.AutoSize = true;
            ProfitReportLabel.Font = new Font("Arial", 25F, FontStyle.Bold, GraphicsUnit.Point);
            ProfitReportLabel.ForeColor = SystemColors.Control;
            ProfitReportLabel.Location = new Point(25, 8);
            ProfitReportLabel.Name = "ProfitReportLabel";
            ProfitReportLabel.Size = new Size(547, 49);
            ProfitReportLabel.TabIndex = 4;
            ProfitReportLabel.Text = "Profit Report Management";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(57, 95);
            label1.Name = "label1";
            label1.Size = new Size(273, 23);
            label1.TabIndex = 5;
            label1.Text = "Select a range to show report: ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(ProfitReportLabel);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1434, 59);
            panel1.TabIndex = 6;
            // 
            // ProfitReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 886);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(dgvReport);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnShowReport);
            Name = "ProfitReport";
            Text = "ProfitReport";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnShowReport;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridView dgvReport;
        private Label ProfitReportLabel;
        private Label label1;
        private Panel panel1;
    }
}