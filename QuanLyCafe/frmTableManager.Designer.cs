
namespace QuanLyCafe
{
    partial class frmTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.nmProuctCount = new System.Windows.Forms.NumericUpDown();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmProuctCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdmin,
            this.tsmiAccountProfile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAdmin
            // 
            this.tsmiAdmin.Name = "tsmiAdmin";
            this.tsmiAdmin.Size = new System.Drawing.Size(55, 20);
            this.tsmiAdmin.Text = "Admin";
            this.tsmiAdmin.Click += new System.EventHandler(this.tsmiAdmin_Click);
            // 
            // tsmiAccountProfile
            // 
            this.tsmiAccountProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangeInfo,
            this.tsmiLogOut});
            this.tsmiAccountProfile.Name = "tsmiAccountProfile";
            this.tsmiAccountProfile.Size = new System.Drawing.Size(115, 20);
            this.tsmiAccountProfile.Text = "Thông tin cá nhân";
            // 
            // tsmiChangeInfo
            // 
            this.tsmiChangeInfo.Name = "tsmiChangeInfo";
            this.tsmiChangeInfo.Size = new System.Drawing.Size(224, 22);
            this.tsmiChangeInfo.Text = "Chỉnh sửa thông tin cá nhân";
            this.tsmiChangeInfo.Click += new System.EventHandler(this.tsmiChangeInfo_Click);
            // 
            // tsmiLogOut
            // 
            this.tsmiLogOut.Name = "tsmiLogOut";
            this.tsmiLogOut.Size = new System.Drawing.Size(224, 22);
            this.tsmiLogOut.Text = "Đăng xuất";
            this.tsmiLogOut.Click += new System.EventHandler(this.tsmiLogOut_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 359);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 4);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(324, 347);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 54;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 80;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtbTotalPrice);
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.nudDiscount);
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Controls.Add(this.btnDiscount);
            this.panel3.Location = new System.Drawing.Point(12, 392);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 57);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tổng tiền";
            // 
            // txtbTotalPrice
            // 
            this.txtbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTotalPrice.ForeColor = System.Drawing.Color.Brown;
            this.txtbTotalPrice.Location = new System.Drawing.Point(248, 31);
            this.txtbTotalPrice.Name = "txtbTotalPrice";
            this.txtbTotalPrice.ReadOnly = true;
            this.txtbTotalPrice.Size = new System.Drawing.Size(74, 20);
            this.txtbTotalPrice.TabIndex = 3;
            this.txtbTotalPrice.Text = "0";
            this.txtbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(96, 32);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(79, 21);
            this.cbSwitchTable.TabIndex = 1;
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(3, 32);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(75, 20);
            this.nudDiscount.TabIndex = 1;
            this.nudDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(245, 3);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(77, 23);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(96, 3);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(79, 23);
            this.btnSwitchTable.TabIndex = 2;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(3, 3);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(75, 23);
            this.btnDiscount.TabIndex = 1;
            this.btnDiscount.Text = "Giảm giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddProduct);
            this.panel4.Controls.Add(this.nmProuctCount);
            this.panel4.Controls.Add(this.cbProduct);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(348, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(422, 36);
            this.panel4.TabIndex = 4;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(344, 4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Thêm món";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // nmProuctCount
            // 
            this.nmProuctCount.Location = new System.Drawing.Point(281, 4);
            this.nmProuctCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmProuctCount.Name = "nmProuctCount";
            this.nmProuctCount.Size = new System.Drawing.Size(45, 20);
            this.nmProuctCount.TabIndex = 1;
            this.nmProuctCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(142, 5);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(133, 21);
            this.cbProduct.TabIndex = 0;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(4, 5);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(133, 21);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(348, 69);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(422, 380);
            this.flpTable.TabIndex = 5;
            // 
            // frmTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 461);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý dịch vụ Cafe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmProuctCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.NumericUpDown nmProuctCount;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtbTotalPrice;
        private System.Windows.Forms.Label label1;
    }
}