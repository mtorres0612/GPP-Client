using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientDB;
using GPPClientModel;
using System.Data.SqlClient;
namespace GPPClientDAL
{
    public class TransmissionTypeDAL: IMaintainableDAL<TransmissionType>
    {
        static TransmissionTypeDAL _instance;

        public static TransmissionTypeDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new TransmissionTypeDAL();
            }
            return _instance;
        }

        public List<TransmissionType> GetAll()
        {
            string query                = "FT_TransmissionTypeSelProc";
            DataTable dt                = new DataTable();
            List<TransmissionType> list = new List<TransmissionType>();
            dt                          = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                TransmissionType item            = new TransmissionType();
                item.TransmissionTypeID          = Convert.ToInt32(dr["TransmissionTypeID"]);
                item.TransmissionTypeCode        = dr["TransmissionTypeCode"].ToString();
                item.TransmissionTypeDescription = dr["TransmissionTypeDescription"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(TransmissionType item)
        {
            string query = "FT_TransmissionTypeInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@transmissionTypeCode", item.TransmissionTypeCode),
                new SqlParameter("@transmissionTypeDescription", item.TransmissionTypeDescription),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(TransmissionType item)
        {
            string query = "FT_TransmissionTypeUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@transmissionTypeID", item.TransmissionTypeID),
                new SqlParameter("@transmissionTypeCode", item.TransmissionTypeCode),
                new SqlParameter("@transmissionTypeDescription", item.TransmissionTypeDescription),
                sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_TransmissionTypeDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@transmissionTypeID", Convert.ToInt32(id)),
                sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
