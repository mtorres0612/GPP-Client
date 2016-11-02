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
    public class NetworkSettingDAL : IMaintainableDAL<NetworkSetting>
    {
        static NetworkSettingDAL _instance;

        public static NetworkSettingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new NetworkSettingDAL();
            }
            return _instance;
        }

        public List<NetworkSetting> GetAll(int fileTransferSettingId)
        {
            string query = "FT_NetworkSettingSelProc";
            DataTable dt = new DataTable();
            List<NetworkSetting> list = new List<NetworkSetting>();

            SqlParameter[] sqlParams = 
            { 
                new SqlParameter("@fileTransferSettingId", fileTransferSettingId) 
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                NetworkSetting item        = new NetworkSetting();
                item.IDNo                  = Convert.ToInt32(dt.Rows[0]["IDno"]);
                item.FileTransferSettingID = Convert.ToInt32(dt.Rows[0]["FileTransferSettingID"]);
                item.Path                  = dt.Rows[0]["Path"].ToString();
                item.UserName              = dt.Rows[0]["Username"].ToString();
                item.Password              = GPPUtilities.Utility.Decrypt(dt.Rows[0]["Password"].ToString());

                list.Add(item);
            }

            return list;
        }

        public List<NetworkSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(NetworkSetting item)
        {
            throw new NotImplementedException();
        }

        public int Update(NetworkSetting item)
        {
            string query = "FT_NetworkSettingUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@Path", item.Path),
                new SqlParameter("@messageFileID", item.MessageFileID),
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
            string query = "FT_NetworkSettingDelProc";
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
