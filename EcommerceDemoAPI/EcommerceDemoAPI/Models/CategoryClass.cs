using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EcommerceDemoAPI.Models
{
    public class CategoryClass
    {
        public int ProdCatId { get; set; }
        public int CategoryName { get; set; }
        public List<CategoryClass> GetCategory()
        {
            List<CategoryClass> lstCategory = new List<CategoryClass>();
            try
            {

           
           
            DBConnection db = new DBConnection();
           SqlCommand cmd = new SqlCommand();
            cmd.Connection = db.ConOpen();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText="Select ProdCatId,CategoryName from ProductCategory";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            db.ConClose();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                CategoryClass Category =new CategoryClass();
                Category.ProdCatId=Convert.ToInt32(dr["ProdCatId"]);
                Category.CategoryName = Convert.ToInt32(dr["CategoryName"]);
               lstCategory.Add(Category);
               
            }
            }
            catch (Exception ex)
            {
               
                throw;
            }
            return lstCategory;
        }
        
    }
}