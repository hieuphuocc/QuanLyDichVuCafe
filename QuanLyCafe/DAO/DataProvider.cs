using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyCafe.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        private string cnstr = "Data Source=DESKTOP-TAEG4G1;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public DataTable ExecuteQuery(string sql, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (parameter != null)
                {
                    string[] listParameter = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string sql, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (parameter != null)
                {
                    string[] listParameter = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string sql, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (parameter != null)
                {
                    string[] listParameter = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
