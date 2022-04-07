using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EcommerceDemoAPI
{
    public class DBConnection
    {
        string MyConString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
       public SqlConnection ConOpen()
        {
            SqlConnection con = new SqlConnection(MyConString);
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.Open();
            }
            return con;
        }
       public SqlConnection ConClose()
       {
           SqlConnection con = new SqlConnection(MyConString);
           if (con.State == ConnectionState.Open)
           {
               con.Close();
           }
           return con;
       }
        
    }
}