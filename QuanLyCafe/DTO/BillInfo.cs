using System.Data;

namespace QuanLyCafe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int productID,int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.ProductID = productID;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["billID"];
            this.ProductID = (int)row["productID"];
            this.Count = (int)row["count"];
        }
        private int count;
        private int productID;
        private int billID;
        private int iD;
        public int ID { get { return iD; } set { iD = value; } }
        public int Count { get { return count; } set { count = value; } }
        public int ProductID { get { return productID; } set { productID = value; } }
        public int BillID { get { return billID; } set { billID = value; } }
    }
}
