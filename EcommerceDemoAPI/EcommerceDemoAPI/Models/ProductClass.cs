using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EcommerceDemoAPI.Models
{
    public class ProductClass
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProdCatId { get; set; }
        public string ProdCatName { get; set; }

        public List<ProductClass> GetProduct(int ID=0)
        {
            List<ProductClass> lstProduct = new List<ProductClass>();
            try
            {

                DBConnection db = new DBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.ConOpen();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_Product";
                cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = "Get";
                cmd.Parameters.AddWithValue("@prodID", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                db.ConClose();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ProductClass pc = new ProductClass();
                    pc.ProductID = Convert.ToInt32(dr["ProductId"]);
                    pc.ProdCatId = Convert.ToInt32(dr["ProdCatId"]);
                    pc.ProductName = dr["ProdName"].ToString();
                    pc.ProductDescription = dr["ProdDescription"].ToString();
                    pc.ProdCatName = dr["CategoryName"].ToString();
                    lstProduct.Add(pc);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return lstProduct;
        }
        public bool AddProduct(ProductClass product)
        {
            try
            {
                DBConnection db = new DBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.ConOpen();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_Product";
                cmd.Parameters.AddWithValue("@ProdCatId", SqlDbType.Int).Value = product.ProdCatId;
                cmd.Parameters.AddWithValue("@ProdName", SqlDbType.VarChar).Value = product.ProductName;
                cmd.Parameters.AddWithValue("@ProdDescription", SqlDbType.VarChar).Value = product.ProductDescription;
                cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = "INSERT";
                

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        public bool EditProduct(ProductClass product)
        {
            try
            {
                DBConnection db = new DBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.ConOpen();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_Product";
                cmd.Parameters.AddWithValue("@ProdId", SqlDbType.Int).Value = product.ProductID;
                cmd.Parameters.AddWithValue("@ProdCatId", SqlDbType.Int).Value = product.ProdCatId;
                cmd.Parameters.AddWithValue("@ProdName", SqlDbType.VarChar).Value = product.ProductName;
                cmd.Parameters.AddWithValue("@ProdDescription", SqlDbType.VarChar).Value = product.ProductDescription;
                cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = "Update";


                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        public bool DeleteProduct(int Id)
        {
            try
            {
                DBConnection db = new DBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.ConOpen();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_Product";
                cmd.Parameters.AddWithValue("@ProdId", SqlDbType.Int).Value = Id;
                cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = "Delete";
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}