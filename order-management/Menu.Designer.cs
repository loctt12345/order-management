namespace order_management
{
    partial class Menu
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
            btnOrder = new Button();
            btnChef = new Button();
            btnProductManagment = new Button();
            btnProfit = new Button();
            SuspendLayout();
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(31, 24);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(255, 40);
            btnOrder.TabIndex = 0;
            btnOrder.Text = "Màn hình đặt hàng";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnChef
            // 
            btnChef.Location = new Point(31, 88);
            btnChef.Name = "btnChef";
            btnChef.Size = new Size(255, 40);
            btnChef.TabIndex = 1;
            btnChef.Text = "Màn hình bếp";
            btnChef.UseVisualStyleBackColor = true;
            btnChef.Click += btnChef_Click;
            // 
            // btnProductManagment
            // 
            btnProductManagment.Location = new Point(31, 150);
            btnProductManagment.Name = "btnProductManagment";
            btnProductManagment.Size = new Size(255, 40);
            btnProductManagment.TabIndex = 2;
            btnProductManagment.Text = "Quản lí sản phẩm";
            btnProductManagment.UseVisualStyleBackColor = true;
            btnProductManagment.Click += btnProductManagment_Click;
            // 
            // btnProfit
            // 
            btnProfit.Location = new Point(31, 217);
            btnProfit.Name = "btnProfit";
            btnProfit.Size = new Size(255, 40);
            btnProfit.TabIndex = 3;
            btnProfit.Text = "Quản lí doanh thu";
            btnProfit.UseVisualStyleBackColor = true;
            btnProfit.Click += btnProfit_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 269);
            Controls.Add(btnProfit);
            Controls.Add(btnProductManagment);
            Controls.Add(btnChef);
            Controls.Add(btnOrder);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOrder;
        private Button btnChef;
        private Button btnProductManagment;
        private Button btnProfit;
    }
}