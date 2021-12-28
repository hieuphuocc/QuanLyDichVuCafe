using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;
            if (checkLogin(username,password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUsername(username);
                frmTableManager t = new frmTableManager(loginAccount);
                this.Hide();
                t.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("           Thông tin đăng nhập không đúng!");
            }
        }
        bool checkLogin(string username , string password)
        {
            return AccountDAO.Instance.Login(username,password);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("               Xác nhận thoát?", "Thông báo",MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
