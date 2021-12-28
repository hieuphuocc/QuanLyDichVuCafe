using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? date_checkin, DateTime? date_checkout, int status, int discount =0)
        {
            this.ID = id;
            this.Date_CheckIn = date_checkin;
            this.Date_CheckOut = date_checkout;
            this.Status = status;
            this.Discount = discount;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Date_CheckIn = (DateTime?)row["date_checkin"];
            var date_checkouttemp = row["date_checkout"];
            if (date_checkouttemp.ToString() != "")
                this.Date_CheckOut = (DateTime?)date_checkouttemp;
            this.Status = (int)row["status"];

            if(row["discount"].ToString() != "")
                this.discount = (int)row["discount"];
        }
        private int iD;
        private int status;
        private DateTime? date_checkin;
        private DateTime? date_checkout;
        private int discount;
        public int Status { get { return status; } set { status = value; } }
        public int ID { get { return iD; } set { iD = value; } }
        public DateTime? Date_CheckIn { get { return date_checkin; } set { date_checkin = value; } }
        public DateTime? Date_CheckOut { get { return date_checkout; } set { date_checkout = value; } }
        public int Discount { get { return discount; } set { discount = value; } }

    }
}
