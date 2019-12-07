using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem.AllClass
{
    public class DataStore
    {
        String connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public DataTable GetData(string query)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public int Executequery(string query)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}