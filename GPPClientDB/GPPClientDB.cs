using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDB
{
    public class GPPClientDB
    {
        static string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetData(string query, SqlParameter[] sqlParams = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;

                        if (sqlParams != null)
                        {
                            foreach (var item in sqlParams)
                            {
                                com.Parameters.Add(item);
                            }
                        }

                        SqlDataReader dr = com.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

            }

            return dt;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] sqlParams)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;

                        if (sqlParams != null)
                        {
                            foreach (var item in sqlParams)
                            {
                                com.Parameters.Add(item);
                            }
                        }

                        rowsAffected = com.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                return rowsAffected;
            }

            return rowsAffected;
        }

        public static object ExecuteScalar(string query, SqlParameter[] sqlParams)
        {
            object result = 0;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(query, con))
                {
                    if (sqlParams != null)
                    {
                        foreach (var item in sqlParams)
                        {
                            com.Parameters.Add(item);
                        }
                    }

                    result = com.ExecuteScalar();
                }
                con.Close();
            }

            return result;
        }
    }
}
