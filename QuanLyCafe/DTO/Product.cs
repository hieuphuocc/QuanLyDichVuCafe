using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Product
    {
        public Product(int id, string name,float price,int categoryID)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.CategoryID = categoryID;
        }
        public Product(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.CategoryID = (int)row["category_id"];
        }
        private int iD;
        private string name;
        private float price;
        private int categoryID;
        public int ID { get { return iD; } set { iD = value; } }
        public string Name { get { return name; } set { name = value; } }
        public float Price { get { return price; } set { price = value; } }
        public int CategoryID { get { return categoryID; } set { categoryID = value; } }
    }
}
