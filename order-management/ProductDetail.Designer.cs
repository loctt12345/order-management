namespace order_management
{
    partial class ProductDetail
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
            this.lbProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAddOrderDetail = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbProductName.Location = new System.Drawing.Point(12, 3);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(273, 50);
            this.lbProductName.TabIndex = 0;
            this.lbProductName.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(54, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Price       :";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPrice.Location = new System.Drawing.Point(170, 63);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(57, 25);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(54, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantity : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(54, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Note       :";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(170, 145);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(279, 56);
            this.txtNote.TabIndex = 6;
            // 
            // btnAddOrderDetail
            // 
            this.btnAddOrderDetail.Location = new System.Drawing.Point(376, 226);
            this.btnAddOrderDetail.Name = "btnAddOrderDetail";
            this.btnAddOrderDetail.Size = new System.Drawing.Size(73, 23);
            this.btnAddOrderDetail.TabIndex = 7;
            this.btnAddOrderDetail.Text = "Add";
            this.btnAddOrderDetail.UseVisualStyleBackColor = true;
            this.btnAddOrderDetail.Click += new System.EventHandler(this.btnAddOrderDetail_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(170, 106);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(63, 23);
            this.txtQuantity.TabIndex = 8;
            // 
            // txtCancel
            // 
            this.txtCancel.Location = new System.Drawing.Point(288, 226);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(67, 23);
            this.txtCancel.TabIndex = 9;
            this.txtCancel.Text = "Cancel";
            this.txtCancel.UseVisualStyleBackColor = true;
            this.txtCancel.Click += new System.EventHandler(this.txtCancel_Click);
            // 
            // ProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.txtCancel);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnAddOrderDetail);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProductName);
            this.Name = "ProductDetail";
            this.Text = "ProductDetail";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbProductName;
        private Label label1;
        private Label lbPrice;
        private Label label2;
        private Label label3;
        private TextBox txtNote;
        private Button btnAddOrderDetail;
        private NumericUpDown txtQuantity;
        private Button txtCancel;
    }
}