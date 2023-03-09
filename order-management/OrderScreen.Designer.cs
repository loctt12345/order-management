namespace order_management
{
    partial class OrderScreen
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
            btnSearch = new Button();
            dgvOrder = new DataGridView();
            txtOrderID = new TextBox();
            lbOrderID = new Label();
            btnAddNewOrder = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrder).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(416, 49);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 34);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvOrder
            // 
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvOrder.BorderStyle = BorderStyle.Fixed3D;
            dgvOrder.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrder.Location = new Point(14, 92);
            dgvOrder.Margin = new Padding(3, 4, 3, 4);
            dgvOrder.Name = "dgvOrder";
            dgvOrder.RowHeadersWidth = 51;
            dgvOrder.RowTemplate.Height = 25;
            dgvOrder.Size = new Size(887, 472);
            dgvOrder.TabIndex = 1;
            dgvOrder.CellContentDoubleClick += dgvOrder_CellContentDoubleClick;
            // 
            // txtOrderID
            // 
            txtOrderID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderID.Location = new Point(190, 49);
            txtOrderID.Margin = new Padding(3, 4, 3, 4);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.Size = new Size(199, 34);
            txtOrderID.TabIndex = 2;
            // 
            // lbOrderID
            // 
            lbOrderID.AutoSize = true;
            lbOrderID.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbOrderID.Location = new Point(14, 52);
            lbOrderID.Name = "lbOrderID";
            lbOrderID.Size = new Size(170, 23);
            lbOrderID.TabIndex = 3;
            lbOrderID.Text = "Search by order ID: ";
            // 
            // btnAddNewOrder
            // 
            btnAddNewOrder.Location = new Point(728, 45);
            btnAddNewOrder.Margin = new Padding(3, 4, 3, 4);
            btnAddNewOrder.Name = "btnAddNewOrder";
            btnAddNewOrder.Size = new Size(173, 39);
            btnAddNewOrder.TabIndex = 4;
            btnAddNewOrder.Text = "Add new order";
            btnAddNewOrder.UseVisualStyleBackColor = true;
            btnAddNewOrder.Click += btnAddNewOrder_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(14, 12);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(73, 27);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // OrderScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(914, 600);
            Controls.Add(btnRefresh);
            Controls.Add(btnAddNewOrder);
            Controls.Add(lbOrderID);
            Controls.Add(txtOrderID);
            Controls.Add(dgvOrder);
            Controls.Add(btnSearch);
            Margin = new Padding(3, 4, 3, 4);
            Name = "OrderScreen";
            Text = "OrderScreen";
            ((System.ComponentModel.ISupportInitialize)dgvOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dgvOrder;
        private TextBox txtOrderID;
        private Label lbOrderID;
        private Button btnAddNewOrder;
        private Button btnRefresh;
    }
}