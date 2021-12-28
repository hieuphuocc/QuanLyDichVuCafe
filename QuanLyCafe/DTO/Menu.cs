using System;
using System.Data;

namespace QuanLyCafe.DTO
{
    public class Menu
    {
        public Menu(string foodName, int count, float price, float totalPrice = 0)
        {
            this.ProductName = productName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu(DataRow row)
        {
            this.ProductName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        private string productName;
        private int count;
        private float price;
        private float totalPrice;
        public string ProductName { get { return productName; } set { productName = value; } }
        public int Count { get { return count; } set { count = value; } }
        public float Price { get { return price; } set { price = value; } }
        public float TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
    }
}
