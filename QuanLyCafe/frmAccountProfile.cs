using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmAccountProfile : Form
    {
        private Account loginAccount;
        public Account LoginAccount { get { return loginAccount; } set { loginAccount = value; ChangeAccount(LoginAccount); } }
        public frmAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            txtbUsername.Text = LoginAccount.Username;
            txtbName.Text = LoginAccount.Name;
        }
        void UpdateAccountProfile()
        {
            string username = txtbUsername.Text;
            string name = txtbName.Text;
            string password = txtbPassword.Text;
            string newpassword = txtbNewPwd.Text;
            string confirmpassword = txtbConfirmPwd.Text;
            if (!newpassword.Equals(confirmpassword))
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccountProfile(username, name, password, newpassword))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    if(updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUsername(username)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                }
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateAccountProfile();
        }
    }
    public class AccountEvent: EventArgs
    {
        private Account acc;
        public Account Acc { get { return acc; } set { acc = value; } }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
