using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDAL
{
    public class SupplierDAL : IMaintainableDAL<Supplier>
    {
        static SupplierDAL _instance;

        public static SupplierDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SupplierDAL();
            }
            return _instance;
        }

        public List<Supplier> GetAll()
        {
            string query        = "FT_SupplierSelProc";
            DataTable dt        = new DataTable();
            List<Supplier> list = new List<Supplier>();
            dt                  = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                Supplier item    = new Supplier();
                item.SuppID      = dr["suppID"].ToString();
                item.Name        = dr["suppName"].ToString();
                item.Addr1       = dr["suppAddr1"].ToString();
                item.Addr2       = dr["suppAddr2"].ToString();
                item.City        = dr["suppCity"].ToString();
                item.State       = dr["suppState"].ToString();
                item.PostCode    = dr["suppPostCode"].ToString();
                item.CountryLU   = dr["suppCountryLU"].ToString();
                item.Email       = dr["suppEmail"].ToString();
                item.Fax         = dr["suppFax"].ToString();
                item.Phone       = dr["suppPhone"].ToString();
                item.HomePageURL = dr["suppHomepageURL"].ToString();
                item.ERPType     = dr["suppERPType"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(Supplier item)
        {
            string query = "FT_SupplierInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@suppID", item.SuppID),
                new SqlParameter("@suppName", item.Name),
                new SqlParameter("@suppAddr1", item.Addr1),
                new SqlParameter("@suppAddr2", item.Addr2),
                new SqlParameter("@suppCity", item.City),
                new SqlParameter("@suppState", item.State),
                new SqlParameter("@suppPostCode", item.PostCode),
                new SqlParameter("@suppCountryLU", item.CountryLU),
                new SqlParameter("@suppEmail", item.Email),
                new SqlParameter("@suppFax", item.Fax),
                new SqlParameter("@suppPhone", item.Phone),
                new SqlParameter("@suppHomepageURL", item.HomePageURL),
                new SqlParameter("@suppERPType", item.ERPType),
                new SqlParameter("@user", item.User),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(Supplier item)
        {
            string query = "FT_SupplierUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@suppID", item.SuppID),
                new SqlParameter("@suppName", item.Name),
                new SqlParameter("@suppAddr1", item.Addr1),
                new SqlParameter("@suppAddr2", item.Addr2),
                new SqlParameter("@suppCity", item.City),
                new SqlParameter("@suppState", item.State),
                new SqlParameter("@suppPostCode", item.PostCode),
                new SqlParameter("@suppCountryLU", item.CountryLU),
                new SqlParameter("@suppEmail", item.Email),
                new SqlParameter("@suppFax", item.Fax),
                new SqlParameter("@suppPhone", item.Phone),
                new SqlParameter("@suppHomepageURL", item.HomePageURL),
                new SqlParameter("@suppERPType", item.ERPType),
                new SqlParameter("@user", item.User),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_SupplierDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@supplierID", Convert.ToString(id)),
                sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
