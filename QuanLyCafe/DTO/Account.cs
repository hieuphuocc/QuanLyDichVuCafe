using System.Data;

namespace QuanLyCafe.DTO
{
    public class Account
    {
        public Account(string username, string name, int account_role,string password = null)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Account_role = account_role;
        }
        public Account(DataRow row)
        {
            this.Username = row["username"].ToString();
            this.Password = row["password"].ToString();
            this.Name = row["name"].ToString();
            this.Account_role = (int)row["account_role"];
        }
        private string username;
        private string password;
        private string name;
        private int account_role;
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Account_role { get { return account_role; } set { account_role = value; } }
    }
}