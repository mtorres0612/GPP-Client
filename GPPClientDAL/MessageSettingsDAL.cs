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
    public class MessageSettingsDAL : IMaintainableDAL<MessageSettings>
    {
        static MessageSettingsDAL _instance;

        public static MessageSettingsDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new MessageSettingsDAL();
            }
            return _instance;
        }

        public List<MessageSettings> GetAll(string msgCode)
        {
            string query               = "FT_MessageSettingsSelProc";
            DataTable dt               = new DataTable();
            List<MessageSettings> list = new List<MessageSettings>();

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@msgcode", msgCode)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                MessageSettings item         = new MessageSettings();
                item.MsetID                  = Convert.ToInt32(dr["MsetID"]);
                item.MsgCode                 = dr["MsgCode"].ToString();
                item.ERP                     = dr["ERP"].ToString();
                item.PRNCPL                  = dr["PRNCPL"].ToString();
                item.FileType                = dr["MsetFileType"].ToString();
                item.FtpServerIP             = dr["MsetFTPServerIP"].ToString();
                item.FtpPort                 = dr["MsetFTPPort"].ToString();
                item.FtpFolder               = dr["MsetFTPFolder"].ToString();
                item.FtpUserName             = dr["MsetFTPUserName"].ToString();
                item.FtpPassword             = dr["MsetFTPPassword"].ToString();
                item.FtpBeforePutCmd         = dr["MsetFTPBeforePutCmd"].ToString();
                item.BackUpFolder            = dr["MsetBackUpFolder"].ToString();
                item.BackUpFolderOut         = dr["MsetBackUpFolderOut"].ToString();
                item.NoMappingFolder         = dr["MsetNoMappingFolder"].ToString();
                item.NoFTPSettingsFolder     = dr["MsetNoFTPSettingsFolder"].ToString();
                item.NotValidFolder          = dr["MsetNotValidFolder"].ToString();
                item.SendSuccessNotification = Convert.ToBoolean(dr["MsetSendSuccessNotification"]);
                item.MessageFileSourceId     = 0;
                item.SourceFileMask          = dr["MsetSourceFileMask"].ToString();
                item.FITEMask                = dr["MsetFITEMask"].ToString();
                item.IsZip                   = Convert.ToBoolean(dr["MsetIsZip"]);
                item.ZipPassword             = dr["MsetZipPassword"].ToString();
                item.IsZipSource             = Convert.ToBoolean(dr["MsetIsZipSource"]);
                item.FilesSentStatusSingle   = Convert.ToBoolean(dr["MsetFilesSentSingle"]);
                item.FilesSentStatusBatch    = Convert.ToBoolean(dr["MsetFilesSentBatch"]);
                item.FileConvertionFlag      = Convert.ToBoolean(dr["MsetFileConvertionFlag"]);

                if (dr["MessageFileSourceId"] != DBNull.Value)
                    item.MessageFileSourceId = Convert.ToInt32(dr["MessageFileSourceId"]);

                item.MessageFileDestinationId = 0;
                if (dr["MessageFileDestinationId"] != DBNull.Value)
                    item.MessageFileDestinationId = Convert.ToInt32(dr["MessageFileDestinationId"]);

                if (dr["MsetRetention"] != DBNull.Value)
                    item.Retention = Convert.ToInt32(dr["MsetRetention"]);

                if (dr["MsetSourceCodePage"] == System.DBNull.Value)
                { item.SourceCodePage = 0; }
                else
                { item.SourceCodePage = Convert.ToInt32(dr["MsetSourceCodePage"]); }

                if (dr["MsetSourceCodePage"] == System.DBNull.Value)
                { item.DestinationCodePage = 0; }
                else
                { item.DestinationCodePage = Convert.ToInt32(dr["MsetDestinationCodePage"]); }

                if (dr["MsetFilePickupDelay"].ToString().Equals(string.Empty))
                { item.MsetFilePickupDelay = 1; }
                else
                { item.MsetFilePickupDelay = Convert.ToInt32(dr["MsetFilePickupDelay"]); }

                if (dr["MsetBatchRun"].ToString().Equals(string.Empty))
                { item.MsetBatchRun = false; }
                else
                { item.MsetBatchRun = Convert.ToBoolean(dr["MsetBatchRun"]); }

                if (dr["MsetBatchTime"].ToString().Equals(string.Empty))
                { 
                    item.MsetBatchTime       = (DateTime)DateTime.Parse("01/01/2008 13:00");
                    item.MsetBatchTimeString = DateTime.Parse("01/01/2008 13:00").ToString("hh:mm:ss tt"); 

                }
                else
                {
                    item.MsetBatchTime       = (DateTime)DateTime.Parse(dr["MsetBatchTime"].ToString());
                    item.MsetBatchTimeString = DateTime.Parse(dr["MsetBatchTime"].ToString()).ToString("hh:mm:ss tt"); 
                }


                if (dr["MsetRunTime"].ToString().Equals(string.Empty))
                { item.MsetRunTime = false; }
                else
                { item.MsetRunTime = Convert.ToBoolean(dr["MsetRunTime"]); }

                if (dr["MsetStartTime"].ToString().Equals(string.Empty))
                {
                    item.MsetStartTime       = (DateTime)DateTime.Parse("01/01/2008 13:00");
                    item.MsetStartTimeString = DateTime.Parse("01/01/2008 13:00").ToString("hh:mm:ss tt");
                }
                else
                { 
                    item.MsetStartTime       = (DateTime)DateTime.Parse(dr["MsetStartTime"].ToString());
                    item.MsetStartTimeString = DateTime.Parse(dr["MsetStartTime"].ToString()).ToString("hh:mm:ss tt");
                }

                if (dr["MsetEndTime"].ToString().Equals(string.Empty))
                { 
                    item.MsetEndTime = (DateTime)DateTime.Parse("01/01/2008 13:00");
                    item.MsetEndTimeString = DateTime.Parse("01/01/2008 13:00").ToString("hh:mm:ss tt");
                }
                else
                { 
                    item.MsetEndTime = (DateTime)DateTime.Parse(dr["MsetEndTime"].ToString());
                    item.MsetEndTimeString = DateTime.Parse(dr["MsetEndTime"].ToString()).ToString("hh:mm:ss tt");

                }

                if (dr["MsetInterval"].ToString().Equals(string.Empty))
                { item.MsetInterval = 0; }
                else
                { item.MsetInterval = Convert.ToInt32(dr["MsetInterval"]); }

                if (dr["MsetMaxThreadCount"].ToString().Equals(string.Empty))
                { item.MsetMaxThreadCount = 0; }
                else
                { item.MsetMaxThreadCount = Convert.ToInt32(dr["MsetMaxThreadCount"]); }

                list.Add(item);
            }

            return list;
        }

        public List<MessageSettings> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(MessageSettings item)
        {
            string query = "FT_MessageSettingsInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@msgCode", item.MsgCode),
                new SqlParameter("@ERP", item.ERP),
                new SqlParameter("@PRNCPL", item.PRNCPL),
                new SqlParameter("@messageFileSourceId", item.MessageFileSourceId),
                new SqlParameter("@msetSourceFileMask", item.SourceFileMask),
                new SqlParameter("@messageFileDestinationId", item.MessageFileDestinationId),
                new SqlParameter("@msetFileType", item.FileType),
                new SqlParameter("@msetFTPServerIP", item.FtpServerIP),
                new SqlParameter("@msetFTPPort", item.FtpPort),
                new SqlParameter("@msetFTPFolder", item.FtpFolder),
                new SqlParameter("@msetFTPUserName", item.FtpUserName),
                new SqlParameter("@msetFTPPassword", item.FtpPassword),
                new SqlParameter("@msetFTPBeforePutCmd", item.FtpBeforePutCmd),
                new SqlParameter("@msetBackUpFolder", item.BackUpFolder),
                new SqlParameter("@msetBackUpFolderOut", item.BackUpFolderOut),
                new SqlParameter("@msetNoMappingFolder", item.NoMappingFolder),
                new SqlParameter("@msetNoFTPSettingsFolder", item.NoFTPSettingsFolder),
                new SqlParameter("@msetNotValidFolder", item.NotValidFolder),
                new SqlParameter("@MsetSendSuccessNotification", item.SendSuccessNotification),                                    
                new SqlParameter("@User", item.User),
                new SqlParameter("@msetFITEMask", item.FITEMask),
                new SqlParameter("@msetIsZip", item.IsZip),
                new SqlParameter("@msetZipPassword", item.ZipPassword),
                new SqlParameter("@MsetIsZipSource", item.IsZipSource),
                new SqlParameter("@msetRetention", item.Retention),
                new SqlParameter("@MsetFilesSentSingle", item.FilesSentStatusSingle),
                new SqlParameter("@MsetFilesSentBatch", item.FilesSentStatusBatch),
                new SqlParameter("@MsetFileConvertionFlag", item.FileConvertionFlag),
                new SqlParameter("@MsetSourceCodePage", item.SourceCodePage),
                new SqlParameter("@MsetDestinationCodePage", item.DestinationCodePage),
                new SqlParameter("@MsetFilePickupDelay", item.MsetFilePickupDelay),
                new SqlParameter("@MsetBatchRun", item.MsetBatchRun),
                new SqlParameter("@MsetBatchTime", item.MsetBatchTime),
                new SqlParameter("@MsetRunTime", item.MsetRunTime),
                new SqlParameter("@MsetStartTime", item.MsetStartTime),
                new SqlParameter("@MsetEndTime", item.MsetEndTime),
                new SqlParameter("@MsetInterval", item.MsetInterval),
                new SqlParameter("@MsetMaxThreadCount", item.MsetMaxThreadCount),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(MessageSettings item)
        {
            string query = "FT_MessageSettingsUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@msetID", item.MsetID),
                new SqlParameter("@msgCode", item.MsgCode),
                new SqlParameter("@ERP", item.ERP),
                new SqlParameter("@PRNCPL", item.PRNCPL),
                new SqlParameter("@messageFileSourceId", item.MessageFileSourceId),
                new SqlParameter("@msetSourceFileMask", item.SourceFileMask),
                new SqlParameter("@messageFileDestinationId", item.MessageFileDestinationId),
                new SqlParameter("@msetFileType", item.FileType),
                new SqlParameter("@msetFTPServerIP", item.FtpServerIP),
                new SqlParameter("@msetFTPPort", item.FtpPort),
                new SqlParameter("@msetFTPFolder", item.FtpFolder),
                new SqlParameter("@msetFTPUserName", item.FtpUserName),
                new SqlParameter("@msetFTPPassword", item.FtpPassword),
                new SqlParameter("@msetFTPBeforePutCmd", item.FtpBeforePutCmd),
                new SqlParameter("@msetBackUpFolder", item.BackUpFolder),
                new SqlParameter("@msetBackUpFolderOut", item.BackUpFolderOut),
                new SqlParameter("@msetNoMappingFolder", item.NoMappingFolder),
                new SqlParameter("@msetNoFTPSettingsFolder", item.NoFTPSettingsFolder),
                new SqlParameter("@msetNotValidFolder", item.NotValidFolder),
                new SqlParameter("@MsetSendSuccessNotification", item.SendSuccessNotification),                                    
                new SqlParameter("@user", item.User),
                new SqlParameter("@msetFITEMask", item.FITEMask),
                new SqlParameter("@msetIsZip", item.IsZip),
                new SqlParameter("@msetZipPassword", item.ZipPassword),
                new SqlParameter("@MsetIsZipSource", item.IsZipSource),
                new SqlParameter("@msetRetention", item.Retention),
                new SqlParameter("@MsetFilesSentSingle", item.FilesSentStatusSingle),
                new SqlParameter("@MsetFilesSentBatch", item.FilesSentStatusBatch),
                new SqlParameter("@MsetFileConvertionFlag", item.FileConvertionFlag),
                new SqlParameter("@MsetSourceCodePage", item.SourceCodePage),
                new SqlParameter("@MsetDestinationCodePage", item.DestinationCodePage),
                new SqlParameter("@MsetFilePickupDelay", item.MsetFilePickupDelay),
                new SqlParameter("@MsetBatchRun", item.MsetBatchRun),
                new SqlParameter("@MsetBatchTime", item.MsetBatchTime),
                new SqlParameter("@MsetRunTime", item.MsetRunTime),
                new SqlParameter("@MsetStartTime", item.MsetStartTime),
                new SqlParameter("@MsetEndTime", item.MsetEndTime),
                new SqlParameter("@MsetInterval", item.MsetInterval),
                new SqlParameter("@MsetMaxThreadCount", item.MsetMaxThreadCount),
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
