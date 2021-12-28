using QuanLyCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        private BillInfoDAO() { }
        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE BillInfo WHERE product_id = " + id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE bill_id = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public void AddBillInfo(int idBill, int idProduct,int count)
        {
            DataProvider.Instance.ExecuteNonQuery("AddBillInfo @idBill , @idProduct , @count", new object[] { idBill, idProduct, count });
        }
    }
}
