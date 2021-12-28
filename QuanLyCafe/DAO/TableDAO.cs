using QuanLyCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance { get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; } private set { TableDAO.instance = value; } }
        public static int TableWidth = 80;
        public static int TableHeight = 80;
        private TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<Table> GetTableList()
        {
            List<Table> listTable = new List<Table>();
            string sql = "SELECT * FROM TableProduct";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listTable.Add(table);
            }
            return listTable;
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("SwitchTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }
        public bool AddTable(string name)
        {
            string sql = string.Format("INSERT TableProduct(name, status) VALUES (N'{0}', N'Trống')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool UpdateTable(int id, string name)
        {
            string sql = string.Format("Update TableProduct SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool DeleteTable(int id)
        {
            string sql = string.Format("DELETE TableProduct WHERE id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
    }
}
