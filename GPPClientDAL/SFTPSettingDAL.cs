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
    public class SFTPSettingDAL : IMaintainableDAL<SFTPSetting>
    {
        static SFTPSettingDAL _instance;

        public static SFTPSettingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SFTPSettingDAL();
            }
            return _instance;
        }

        public List<SFTPSetting> GetAll(int fileTransferSettingId)
        {
            string query           = "FT_SFTPSettingSelProc";
            DataTable dt           = new DataTable();
            List<SFTPSetting> list = new List<SFTPSetting>();

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileTransferSettingId", fileTransferSettingId)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                SFTPSetting item           = new SFTPSetting();
                item.IDNo                  = Convert.ToInt32(dt.Rows[0]["IDno"]);
                item.FileTransferSettingID = Convert.ToInt32(dt.Rows[0]["FileTransferSettingID"]);
                item.IPAddress             = dt.Rows[0]["IPAddress"].ToString();
                item.Folder                = dt.Rows[0]["Folder"].ToString();
                item.UserName              = dt.Rows[0]["Username"].ToString();
                item.Password              = GPPUtilities.Utility.Decrypt(dt.Rows[0]["Password"].ToString());
                int thisPort               = 0;
                int.TryParse(dt.Rows[0]["PortNumber"].ToString(), out thisPort);
                item.PortNumber            = thisPort;

                list.Add(item);
            }

            return list;
        }

        public List<SFTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(SFTPSetting item)
        {
            string query = "FT_SFTPSettingInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", GPPUtilities.Utility.Encrypt(item.Password)),
                new SqlParameter("@portnumber", item.PortNumber),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(SFTPSetting item)
        {
            string query = "FT_SFTPSettingUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@ipAddress", item.IPAddress),
                new SqlParameter("@folder", item.Folder),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", GPPUtilities.Utility.Encrypt(item.Password)), 
                new SqlParameter("@portnumber", item.PortNumber),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_SFTPSettingDelProc";
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
