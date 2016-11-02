using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using System.Data;
using System.Data.SqlClient;
namespace GPPClientDAL
{
    public class ERPDAL : IMaintainableDAL<ERP>
    {
        static ERPDAL _instance;

        public static ERPDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ERPDAL();
            }
            return _instance;
        }

        public List<ERP> GetAll()
        {
            string query = "FT_ErpSelProc";
            DataTable dt = new DataTable();
            List<ERP> list = new List<ERP>();
            dt = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                ERP item          = new ERP();
                item.Erp          = dr["ERP"].ToString();
                item.SuppID       = dr["SuppID"].ToString();
                item.ErpCountryLU = dr["ERPCountryLU"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(ERP item)
        {
            string query = "FT_ErpInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@ERP", item.Erp),
			   new SqlParameter("@SuppID", item.SuppID),
			   new SqlParameter("@ERPCountryLU", item.ErpCountryLU),
			   new SqlParameter("@user", item.User),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(ERP item)
        {
            string query = "FT_ErpUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@ERP", item.Erp),
			   new SqlParameter("@SuppID", item.SuppID),
			   new SqlParameter("@ERPCountryLU", item.ErpCountryLU),
			   new SqlParameter("@user", item.User),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_ErpDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@ERP", Convert.ToString(id)),
               sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
