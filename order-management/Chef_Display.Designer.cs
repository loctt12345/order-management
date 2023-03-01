namespace order_management
{
    partial class Chef_Display
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConfirm = new Button();
            dgvShowData = new DataGridView();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvShowData).BeginInit();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(662, 540);
            btnConfirm.Margin = new Padding(3, 4, 3, 4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(245, 73);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // dgvShowData
            // 
            dgvShowData.BorderStyle = BorderStyle.None;
            dgvShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShowData.Location = new Point(48, 108);
            dgvShowData.Margin = new Padding(3, 4, 3, 4);
            dgvShowData.Name = "dgvShowData";
            dgvShowData.RowHeadersWidth = 51;
            dgvShowData.RowTemplate.Height = 25;
            dgvShowData.Size = new Size(858, 405);
            dgvShowData.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(48, 39);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(123, 61);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // Chef_Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 629);
            Controls.Add(btnRefresh);
            Controls.Add(btnConfirm);
            Controls.Add(dgvShowData);
            Name = "Chef_Display";
            Text = "Chef_Display";
            ((System.ComponentModel.ISupportInitialize)dgvShowData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnConfirm;
        private DataGridView dgvShowData;
        private Button btnRefresh;
    }
}