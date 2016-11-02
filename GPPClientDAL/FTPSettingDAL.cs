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
    public class FTPSettingDAL : IMaintainableDAL<FTPSetting>
    {
        static FTPSettingDAL _instance;

        public static FTPSettingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FTPSettingDAL();
            }
            return _instance;
        }

        public List<FTPSetting> GetAll(int fileTransferSettingId)
        {
            string query          = "FT_FTPSettingSelProc";
            DataTable dt          = new DataTable();
            List<FTPSetting> list = new List<FTPSetting>();

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileTransferSettingId", fileTransferSettingId)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                FTPSetting item            = new FTPSetting();
                item.IDNo                  = Convert.ToInt32(dt.Rows[0]["IDno"]);
                item.FileTransferSettingID = Convert.ToInt32(dt.Rows[0]["FileTransferSettingID"]);
                item.UserName              = dt.Rows[0]["Username"].ToString();
                item.Password              = GPPUtilities.Utility.Decrypt(dt.Rows[0]["Password"].ToString());
                item.IPAddress             = dt.Rows[0]["IPAddress"].ToString();
                item.Folder                = dt.Rows[0]["Folder"].ToString();
                int thisPort               = 0;
                int.TryParse(dt.Rows[0]["PortNumber"].ToString(), out thisPort);
                item.PortNumber            = thisPort;

                list.Add(item);
            }

            return list;
        }

        public List<FTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(FTPSetting item)
        {
            string query = "FT_FTPSettingInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", GPPUtilities.Utility.Encrypt(item.Password)),
                new SqlParameter("@ipAddress", item.IPAddress),
                new SqlParameter("@folder", item.Folder),
                new SqlParameter("@portnumber", item.PortNumber),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(FTPSetting item)
        {
            string query = "FT_FTPSettingUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", GPPUtilities.Utility.Encrypt(item.Password)),
                new SqlParameter("@ipAddress", item.IPAddress),
                new SqlParameter("@folder", item.Folder),
                new SqlParameter("@portnumber", item.PortNumber),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_FTPSettingDelProc";
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
