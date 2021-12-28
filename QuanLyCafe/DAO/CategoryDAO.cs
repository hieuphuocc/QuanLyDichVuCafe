using QuanLyCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        { get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; } private set { CategoryDAO.instance = value; } }
        private CategoryDAO() { }
        public List<Category> GetCategoryList()
        {
            List<Category> listCategory = new List<Category>();
            string sql = "SELECT * FROM Category";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }
            return listCategory;
        }
        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string sql = "SELECT * FROM Category WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
        public bool AddCategory(string name)
        {
            string sql = string.Format("INSERT Category(name) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool UpdateCategory(int id, string name)
        {
            string sql = string.Format("Update Category SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
        public bool DeleteCategory(int id)
        {
            string sql = string.Format("DELETE Category WHERE id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);
            return result > 0;
        }
    }
}
