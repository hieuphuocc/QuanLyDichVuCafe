using QuanLyCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class ProductDAO
    {
        
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return ProductDAO.instance; }
            private set { ProductDAO.instance = value; }
        }
        private ProductDAO() { }
        public List<Product> GetProductByCategoryID(int id)
        {
            List<Product> listProduct = new List<Product>();

            string query = "SELECT * FROM Product WHERE category_id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                listProduct.Add(product);
            }

            return listProduct;
        }
        public List<Product> GetProductList()
        {
            List<Product> listProduct = new List<Product>();

            string query = "SELECT * FROM Product";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                listProduct.Add(product);
            }

            return listProduct;
        }
        public List<Product> SearchProductByName(string name)
        {
            List<Product> listProduct = new List<Product>();

            string query = string.Format("SELECT * FROM Product WHERE name like N'%{0}%'",name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                listProduct.Add(product);
            }

            return listProduct;
        }
        public bool AddProduct(string name, int category_id , float price)
        {
            string sql = string.Format("INSERT Product(name,category_id,price) VALUES (N'{0}',{1},{2})",name, category_id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool UpdateProduct(int id, string name, int category_id, float price)
        {
            string sql = string.Format("Update Product SET name = N'{0}', category_id = {1}, price = {2} WHERE id = {3}", name, category_id, price,id);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool DeleteProduct(int id)
        {
            string sql = string.Format("DELETE Product WHERE id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
    }
}
