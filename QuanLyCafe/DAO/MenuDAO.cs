using QuanLyCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string sql = "SELECT p.name,bi.count,p.price,p.price*bi.count AS totalPrice FROM BillInfo AS bi, Bill AS b, Product as p WHERE bi.bill_id = b.id AND bi.product_id = p.id AND b.status = 0 AND b.table_id = "+ id;
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}