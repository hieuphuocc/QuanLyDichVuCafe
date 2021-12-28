using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmAdmin : Form
    {
        BindingSource categoryList = new BindingSource();
        BindingSource productList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource tableList = new BindingSource();
        public Account loginAccount;
        public DialogResult AddProduct { get; internal set; }
        public frmAdmin()
        {
            InitializeComponent();
            Load();
        }
        #region methods
        void Load()
        {
            dgvCategory.DataSource = categoryList;
            dgvProduct.DataSource = productList;
            dgvAccount.DataSource = accountList;
            dgvTable.DataSource = tableList;
            LoadAccount();
            LoadProductList();
            LoadCategoryList();
            LoadTableList();
            AddCategoryBinding();
            AddProductBinding();
            AddAccountBinding();
            AddTableBinding();
            LoadCategoryIntoComboBox(cbProductCategory);
        }
        void AddAccount(string username, string name, int account_role)
        {
            if(AccountDAO.Instance.AddAccount(username, name, account_role))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
            LoadAccount();
        }
        void UpdateAccount(string username, string name, int account_role)
        {
            if (AccountDAO.Instance.UpdateAccount(username, name, account_role))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại!");
            }
            LoadAccount();
        }
        void DeleteAccount(string username)
        {
            if (loginAccount.Username.Equals(username))
            {
                MessageBox.Show("Không thể xoá tài khoản hiện tại đang đăng nhập!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xoá tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Xoá tài khoản thất bại!");
            }
            LoadAccount();
        }
        void ResetPassword(string username)
        {
            if (AccountDAO.Instance.ResetPassword(username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại!");
            }
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadCategory()
        {
            string sql = "SELECT * FROM Category";
            dgvCategory.DataSource = DataProvider.Instance.ExecuteQuery(sql);
        }
        void LoadProduct()
        {
            string sql = "SELECT * FROM Product";
            dgvProduct.DataSource = DataProvider.Instance.ExecuteQuery(sql);
        }
        void LoadCategoryList()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetCategoryList();
        }
        void LoadTableList()
        {
            tableList.DataSource = TableDAO.Instance.GetTableList();
        }
        void LoadProductList()
        {
            productList.DataSource = ProductDAO.Instance.GetProductList();
        }
        void LoadListBillByDate(DateTime date_checkin, DateTime date_checkout)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDate(date_checkin, date_checkout);
        }
        void AddCategoryBinding()
        {
            txtbCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtbCategoryName.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void AddProductBinding()
        {
            txtbProductName.DataBindings.Add(new Binding("Text", dgvProduct.DataSource,"Name",true,DataSourceUpdateMode.Never));
            txtbProductID.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nudProductPrice.DataBindings.Add(new Binding("Value", dgvProduct.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void AddAccountBinding()
        {
            txtbUsername.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "username",true,DataSourceUpdateMode.Never));
            txtbName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "name", true, DataSourceUpdateMode.Never));
            nudAccountRole.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "account_role", true, DataSourceUpdateMode.Never));
        }
        void AddTableBinding()
        {
            txtbTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtbTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtbStatus.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetCategoryList();
            cb.DisplayMember = "Name";
        }
        List<Product> SearchProductByName(string name)
        {
            List<Product> listProduct = ProductDAO.Instance.SearchProductByName(name);
            return listProduct;
        }
        #endregion
        #region events
        private void btnViewRevenue_Click(object sender, System.EventArgs e)
        {
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }
        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }
        private void txtbProductID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.SelectedCells.Count > 0)
                {
                    int id = (int)dgvProduct.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                    Category category = CategoryDAO.Instance.GetCategoryByID(id);
                    cbProductCategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbProductCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbProductCategory.SelectedIndex = index;
                }
            }
            catch { }
        }
        private void btnViewTable_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txtbTableName.Text;
            if (TableDAO.Instance.AddTable(name))
            {
                MessageBox.Show("Thêm bàn thành công!");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại!");
            }
        }
        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            string name = txtbTableName.Text;
            int id = Convert.ToInt32(txtbTableID.Text);

            if (TableDAO.Instance.UpdateTable(id,name))
            {
                MessageBox.Show("Cập nhật bàn thành công!");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Cập nhật bàn thất bại!");
            }
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbTableID.Text);

            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xoá bàn thành công!");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Xoá bàn thất bại!");
            }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtbCategoryName.Text;
            if (CategoryDAO.Instance.AddCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadCategoryList();
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!");
            }
        }
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string name = txtbCategoryName.Text;
            int id = Convert.ToInt32(txtbCategoryID.Text);
            if (CategoryDAO.Instance.UpdateCategory(id,name))
            {
                MessageBox.Show("Cập nhật danh mục thành công!");
                LoadCategoryList();
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục thất bại!");
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xoá danh mục thành công!");
                LoadCategoryList();
            }
            else
            {
                MessageBox.Show("Xoá danh mục thất bại!");
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtbProductName.Text;
            int category_id = (cbProductCategory.SelectedItem as Category).ID;
            float price = (float)nudProductPrice.Value;
            if (ProductDAO.Instance.AddProduct(name, category_id, price))
            {
                MessageBox.Show("Thêm sản phẩm thành công!");
                LoadProductList();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!");
            }
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string name = txtbProductName.Text;
            int category_id = (cbProductCategory.SelectedItem as Category).ID;
            float price = (float)nudProductPrice.Value;
            int id = Convert.ToInt32(txtbProductID.Text);

            if (ProductDAO.Instance.UpdateProduct(id, name, category_id, price))
            {
                MessageBox.Show("Cập nhật sản phẩm thành công!");
                LoadProductList();
            }
            else
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại!");
            }
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbProductID.Text);

            if (ProductDAO.Instance.DeleteProduct(id))
            {
                MessageBox.Show("Xoá sản phẩm thành công!");
                LoadProductList();
            }
            else
            {
                MessageBox.Show("Xoá sản phẩm thất bại!");
            }
        }
        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            productList.DataSource = SearchProductByName(txtbSearchProductName.Text);
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string name = txtbName.Text;
            int account_role = (int) nudAccountRole.Value;
            AddAccount(username, name, account_role);
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            DeleteAccount(username);
        }
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string name = txtbName.Text;
            int account_role = (int)nudAccountRole.Value;
            UpdateAccount(username, name, account_role);
        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            ResetPassword(username);
        }
        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        #endregion
    }
}
