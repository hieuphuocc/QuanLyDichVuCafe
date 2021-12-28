using QuanLyCafe.DTO;
using System.Data;

namespace QuanLyCafe.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        { get { if (instance == null) instance = new AccountDAO(); return instance; } private set { instance = value; } }
        private AccountDAO() { }
        public bool Login(string username, string password)
        {
            string sql = "checkLogin @username , @password";
            DataTable result =DataProvider.Instance.ExecuteQuery(sql,new object[] { username, password });
            return result.Rows.Count > 0;
        }
        public bool UpdateAccountProfile(string username, string name, string password, string newpassword)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC UpdateAccount @username , @name , @password , @newpassword", new object[] { username,name, password, newpassword });
            return result > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT username, name, account_role FROM Account");
        }
        public Account GetAccountByUsername (string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Account WHERE username = '" + username + "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool AddAccount(string username, string name, int account_role)
        {
            if (CheckDuplicateUsername(username) == 1)
            {
                string sql = string.Format("INSERT Account(username,name,account_role) VALUES (N'{0}',N'{1}',{2})", username, name, account_role);
                int result = DataProvider.Instance.ExecuteNonQuery(sql);
                return result > 0;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateAccount(string newname, string name, int account_role)
        {
            string sql = string.Format("Update Account SET name = N'{1}' , account_role = {2} WHERE username = N'{0}'", newname, name, account_role);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string sql = string.Format("DELETE Account WHERE username = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string sql = string.Format("UPDATE Account SET password = 0 WHERE username = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public int CheckDuplicateUsername(string username)
        {
            string check = string.Format("SELECT * FROM Account WHERE username = N'{0}'", username);
            var test = DataProvider.Instance.ExecuteScalar(check);
            if (test == null)
                return 1;
            else
                return 0;
        }
    }
}
