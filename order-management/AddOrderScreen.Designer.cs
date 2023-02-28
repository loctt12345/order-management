namespace order_management
{
    partial class AddOrderScreen
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
            dgvProducts = new DataGridView();
            btnSubmitOrder = new Button();
            dgvCurrentOrder = new DataGridView();
            btnPay = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BorderStyle = BorderStyle.Fixed3D;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 29);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowTemplate.Height = 25;
            dgvProducts.Size = new Size(417, 362);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // btnSubmitOrder
            // 
            btnSubmitOrder.Location = new Point(904, 404);
            btnSubmitOrder.Name = "btnSubmitOrder";
            btnSubmitOrder.Size = new Size(140, 34);
            btnSubmitOrder.TabIndex = 1;
            btnSubmitOrder.Text = "Submit order";
            btnSubmitOrder.UseVisualStyleBackColor = true;
            btnSubmitOrder.Click += btnSubmitOrder_Click;
            // 
            // dgvCurrentOrder
            // 
            dgvCurrentOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurrentOrder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCurrentOrder.BorderStyle = BorderStyle.Fixed3D;
            dgvCurrentOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentOrder.Location = new Point(452, 29);
            dgvCurrentOrder.Name = "dgvCurrentOrder";
            dgvCurrentOrder.RowTemplate.Height = 25;
            dgvCurrentOrder.Size = new Size(592, 362);
            dgvCurrentOrder.TabIndex = 2;
            dgvCurrentOrder.CellContentClick += dgvCurrentOrder_CellContentClick;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(743, 404);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(135, 34);
            btnPay.TabIndex = 3;
            btnPay.Text = "Confirm payment";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // AddOrderScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 450);
            Controls.Add(btnPay);
            Controls.Add(dgvCurrentOrder);
            Controls.Add(btnSubmitOrder);
            Controls.Add(dgvProducts);
            Name = "AddOrderScreen";
            Text = "AddOrderScreen";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProducts;
        private Button btnSubmitOrder;
        private DataGridView dgvCurrentOrder;
        private Button btnPay;
    }
}