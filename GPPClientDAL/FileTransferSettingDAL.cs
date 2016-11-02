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
    public class FileTransferSettingDAL : IMaintainableDAL<FileTransferSetting>
    {
        static FileTransferSettingDAL _instance;

        public static FileTransferSettingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileTransferSettingDAL();
            }
            return _instance;
        }

        public List<FileTransferSetting> GetAll(int fileTransferSettingId)
        {
            string query                   = "FT_FileTransferSettingSelProc";
            DataTable dt                   = new DataTable();
            List<FileTransferSetting> list = new List<FileTransferSetting>();

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileTransferSettingID", fileTransferSettingId)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                FileTransferSetting item   = new FileTransferSetting();
                item.FileTransferSettingID = Convert.ToInt32(dr["FileTransferSettingId"].ToString());
                item.MsgCode               = dr["MessageCode"].ToString();
                item.TransmissionTypeID    = Convert.ToInt32(dr["TransmissionTypeId"].ToString());

                list.Add(item);
            }

            return list;
        }

        public List<FileTransferSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(FileTransferSetting item)
        {
            string query = "FT_FileTransferSettingInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@transmissionTypeID", item.TransmissionTypeID),
               new SqlParameter("@msgCode", item.MsgCode),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(FileTransferSetting item)
        {
            string query = "FT_FileTransferSettingUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", item.FileTransferSettingID),                
                new SqlParameter("@transmissionTypeID", item.TransmissionTypeID),
                new SqlParameter("@msgCode", item.MsgCode),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_FileTransferSettingDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTransferSettingID", id),                
                sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
