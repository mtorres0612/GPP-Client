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
    public class HTTPSettingDAL : IMaintainableDAL<HTTPSetting>
    {
        static HTTPSettingDAL _instance;

        public static HTTPSettingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new HTTPSettingDAL();
            }
            return _instance;
        }

        public List<HTTPSetting> GetAll(int fileTransferSettingId)
        {
            string query = "FT_HTTPSettingSelProc";
            DataTable dt = new DataTable();
            List<HTTPSetting> list = new List<HTTPSetting>();

            SqlParameter[] sqlParams = 
            { 
                new SqlParameter("@fileTransferSettingId", fileTransferSettingId) 
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                HTTPSetting item           = new HTTPSetting();
                item.IDNo                  = Convert.ToInt32(dt.Rows[0]["IDno"]);
                item.FileTransferSettingID = Convert.ToInt32(dt.Rows[0]["FileTransferSettingID"]);
                item.URL                   = dt.Rows[0]["URL"].ToString();
                item.UserName              = dt.Rows[0]["Username"].ToString();
                item.Password              = GPPUtilities.Utility.Decrypt(dt.Rows[0]["Password"].ToString());

                list.Add(item);
            }

            return list;
        }

        public List<HTTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(HTTPSetting item)
        {
            string query = "FT_HTTPSettingInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", GPPUtilities.Utility.Encrypt(item.Password)),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(HTTPSetting item)
        {
            string query = "FT_HTTPSettingUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@url", item.URL),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", GPPUtilities.Utility.Encrypt(item.Password)),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_HTTPSettingDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@IDNo", Convert.ToInt32(id)),
                sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
