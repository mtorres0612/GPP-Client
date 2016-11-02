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
    public class SMTPSettingDAL : IMaintainableDAL<SMTPSetting>
    {
        static SMTPSettingDAL _instance;

        public static SMTPSettingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SMTPSettingDAL();
            }
            return _instance;
        }

        public List<SMTPSetting> GetAll(int fileTransferSettingId)
        {
            string query           = "FT_SMTPSettingSelProc";
            DataTable dt           = new DataTable();
            List<SMTPSetting> list = new List<SMTPSetting>();

            SqlParameter[] sqlParams = 
            { 
                new SqlParameter("@fileTransferSettingId", fileTransferSettingId) 
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                SMTPSetting item           = new SMTPSetting();
                item.IDNo                  = Convert.ToInt32(dt.Rows[0]["IDno"]);
                item.FileTransferSettingID = Convert.ToInt32(dt.Rows[0]["FileTransferSettingID"]);
                item.UserName              = dt.Rows[0]["Username"].ToString();
                item.Password              = GPPUtilities.Utility.Decrypt(dt.Rows[0]["Password"].ToString());
                item.SMTPServer            = dt.Rows[0]["SMTPServer"].ToString();

                list.Add(item);
            }

            return list;
        }

        public List<SMTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(SMTPSetting item)
        {
            throw new NotImplementedException();
        }

        public int Update(SMTPSetting item)
        {
            string query = "FT_SMTPSettingUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password", item.Password),
                new SqlParameter("@smtpServer", item.SMTPServer),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = (sqlParamOutput.Value == DBNull.Value) ? 0 : Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
