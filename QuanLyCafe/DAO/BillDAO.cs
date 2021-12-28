using QuanLyCafe.DTO;
using System;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        { get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; } private set { BillDAO.instance = value; } }
        private BillDAO() { }
        public int getBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE table_id = " + id + " AND status = 0");
            if (data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void CheckOut(int id, int discount, float totalPrice)
        {
            string sql = "UPDATE Bill SET date_checkout = GETDATE(), status = 1, " + "discount = "+ discount + ", totalPrice = " + totalPrice + " WHERE id =" +id;
            DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public void AddBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC AddBill @table_id", new object[] { id });
        }
        public DataTable GetBillListByDate(DateTime date_checkin, DateTime date_checkout)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC GetListBillByDate @date_checkin , @date_checkout", new object[] { date_checkin, date_checkout });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) from Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
