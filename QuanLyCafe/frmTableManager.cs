using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Menu = QuanLyCafe.DTO.Menu;

namespace QuanLyCafe
{
    public partial class frmTableManager : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        { get { return loginAccount; } set { loginAccount = value; ChangeAccount(loginAccount.Account_role); } }
        public frmTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }
        #region Method
        void ChangeAccount(int type)
        {
            tsmiAdmin.Enabled = type == 1;
            tsmiAccountProfile.Text += " (" + loginAccount.Name + ")";
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetCategoryList();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }
        void LoadProductListByCategoryID(int id)
        {
            List<Product> listProduct = ProductDAO.Instance.GetProductByCategoryID(id);
            cbProduct.DataSource = listProduct;
            cbProduct.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight
                };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Green;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }
        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.ProductName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            txtbTotalPrice.Text = totalPrice.ToString();
        }
        #endregion

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void tsmiAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin a = new frmAdmin();
            a.loginAccount = loginAccount;
            a.ShowDialog();
        }
        private void tsmiLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmiChangeInfo_Click(object sender, EventArgs e)
        {
            frmAccountProfile ap = new frmAccountProfile(LoginAccount);
            ap.UpdateAccount += Ap_UpdateAccount;
            ap.Show();
        }
        private void Ap_UpdateAccount(object sender, AccountEvent e)
        {
            tsmiAccountProfile.Text = "Thông tin tài khoản(" + e.Acc.Name + ")";
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadProductListByCategoryID(id);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.getBillIDByTableID(table.ID);
            int idProduct = (cbProduct.SelectedItem as Product).ID;
            int count = (int)nmProuctCount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.AddBill(table.ID);
                BillInfoDAO.Instance.AddBillInfo(BillDAO.Instance.GetMaxIDBill(), idProduct, count);
            }
            else
            {
                BillInfoDAO.Instance.AddBillInfo(idBill, idProduct, count);

            }
            ShowBill(table.ID);
            LoadTable();
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.getBillIDByTableID(table.ID);
            int discount = (int)nudDiscount.Value;
            float totalPrice = float.Parse(txtbTotalPrice.Text);
            float totalPriceAfterDiscount = totalPrice - (totalPrice / 100) * discount;
            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Xác nhận thanh toán hoá đơn cho {0}? \nTổng tiền sau khi giảm giá còn {1}", table.Name, totalPriceAfterDiscount), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, totalPriceAfterDiscount);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Xác nhận chuyển bàn {0} qua bàn {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }
        #endregion
    }
}
