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
    public class MessagesDAL : IMaintainableDAL<Messages>
    {
        static MessagesDAL _instance;

        public static MessagesDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new MessagesDAL();
            }
            return _instance;
        }

        public List<Messages> GetAllMessages(string trdpCode = "-1", string msgCode = "")
        {
            string query        = "FT_MessagesSelProc";
            DataTable dt        = new DataTable();
            List<Messages> list = new List<Messages>();

            object objTrdpCode = DBNull.Value;
            if (trdpCode != "-1")
                objTrdpCode = trdpCode;

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@trdpCode", objTrdpCode),
               new SqlParameter("@msgCode", msgCode)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                Messages item                = new Messages();
                item.MsgCode                 = dr["MsgCode"].ToString();
                item.TradingPartnercode      = dr["trdpCode"].ToString();
                item.ColuCode                = dr["coluCode"].ToString();
                item.IsDebug                 = Convert.ToBoolean(dr["MsgIsDebug"]);
                item.Counter                 = null;
                item.Name                    = dr["MsgName"].ToString();
                item.FileType                = dr["MsgFileType"].ToString();
                item.StartReadWrite          = Convert.ToInt32(dr["MsgStartReadWrite"]);
                item.DelLinePattern          = dr["MsgDelLinePattern"].ToString();
                item.CodePageId              = Convert.ToInt32(dr["MSgCodePage"]);
                item.FileNameConvention      = dr["MsgFileNameConvention"].ToString();
                item.FileNameExtension       = dr["MsgFileNameExtension"].ToString();
                item.FileNameDateFormat      = dr["MsgFileNameDateFormat"].ToString();
                item.ExcelTemplatePath       = dr["MsgExcelTemplatePath"].ToString();
                item.ExcelRowOffset          = Convert.ToInt32(dr["MsgExcelRowOffset"]);
                item.ExcelXMLTableNo         = Convert.ToInt32(dr["MsgExcelXMLTableNo"]);
                item.FileDirectionCode       = dr["FileDirectionCode"].ToString();
                item.ApplicationType         = dr["ApluCode"].ToString();
                item.ManualRunFlag           = Convert.ToBoolean(dr["MsgManualRunFlag"].ToString());
                item.TemporaryFileExtension  = dr["MsgTempExtension"].ToString();

                if (dr["MsgCounter"] != DBNull.Value)
                    item.Counter = Convert.ToInt32(dr["MsgCounter"]);

                if (dr["MsgXmlNode"] == DBNull.Value)
                {
                    item.XmlNode = 0;
                }
                else
                {
                    item.XmlNode = Convert.ToInt32(dr["MsgXmlNode"]);
                }

                if (string.IsNullOrEmpty(dr["IsUseTempExtension"].ToString()))
                {
                    item.IsUseTemporaryExtension = false;
                }
                else
                {
                    item.IsUseTemporaryExtension = Convert.ToBoolean(dr["IsUseTempExtension"].ToString());
                }

                if (dr["MsgMonday"].ToString().Equals(string.Empty))
                { 
                    item.MondayFlag = false; 
                }
                else
                { 
                    item.MondayFlag = Convert.ToBoolean(dr["MsgMonday"]); 
                }

                if (dr["MsgTuesday"].ToString().Equals(string.Empty))
                { 
                    item.TuesdayFlag = false; 
                }
                else
                { 
                    item.TuesdayFlag = Convert.ToBoolean(dr["MsgTuesday"]); 
                }

                if (dr["MsgWednesday"].ToString().Equals(string.Empty))
                { 
                    item.WednesdayFlag = false; 
                }
                else
                { 
                    item.WednesdayFlag = Convert.ToBoolean(dr["MsgWednesday"]); 
                }

                if (dr["MsgThursday"].ToString().Equals(string.Empty))
                { 
                    item.ThursdayFlag = false; 
                }
                else
                { 
                    item.ThursdayFlag = Convert.ToBoolean(dr["MsgThursday"]); 
                }

                if (dr["MsgFriday"].ToString().Equals(string.Empty))
                { 
                    item.FridayFlag = false; 
                }
                else
                { 
                    item.FridayFlag = Convert.ToBoolean(dr["MsgFriday"]); 
                }

                if (dr["MsgSaturday"].ToString().Equals(string.Empty))
                { 
                    item.SaturdayFlag = false; 
                }
                else
                { 
                    item.SaturdayFlag = Convert.ToBoolean(dr["MsgSaturday"]); 
                }

                if (dr["MsgSunday"].ToString().Equals(string.Empty))
                { 
                    item.SundayFlag = false; 
                }
                else
                { 
                    item.SundayFlag = Convert.ToBoolean(dr["MsgSunday"]);
                }

                if (dr["MsgStartTime"].ToString().Equals(string.Empty))
                { 
                    item.StartRuntime       = DateTime.Parse("01/01/2008 13:00");
                    item.StartRuntimeString = DateTime.Parse("01/01/2008 13:00").ToString("hh:mm:ss tt");

                }
                else
                { 
                    item.StartRuntime       = DateTime.Parse(dr["MsgStartTime"].ToString());
                    item.StartRuntimeString = DateTime.Parse(dr["MsgStartTime"].ToString()).ToString("hh:mm:ss tt");
                }

                if (dr["MsgEndTime"].ToString().Equals(string.Empty))
                { 
                    item.EndRuntime       = DateTime.Parse("01/01/2008 13:00");
                    item.EndRuntimeString = DateTime.Parse("01/01/2008 13:00").ToString("hh:mm:ss tt");
                }
                else
                { 
                    item.EndRuntime       = DateTime.Parse(dr["MsgEndTime"].ToString());
                    item.EndRuntimeString = DateTime.Parse(dr["MsgEndTime"].ToString()).ToString("hh:mm:ss tt");
                }

                list.Add(item);
            }

            return list;
        }

        public int Insert(Messages item)
        {
            string query = "FT_MessagesInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@msgCode", item.MsgCode),
			   new SqlParameter("@trdpCode", item.TradingPartnercode),
			   new SqlParameter("@coluCode", item.ColuCode),
			   new SqlParameter("@msgIsDebug", item.IsDebug),
			   new SqlParameter("@msgCounter", item.Counter),
			   new SqlParameter("@msgName", item.Name),
			   new SqlParameter("@msgFileType", item.FileType),
			   new SqlParameter("@msgStartReadWrite", item.StartReadWrite),
			   new SqlParameter("@msgDelLinePattern", item.DelLinePattern),
			   new SqlParameter("@msgCodePage", item.CodePageId),
			   new SqlParameter("@msgFileNameConvention", item.FileNameConvention),
			   new SqlParameter("@msgFileNameExtension", item.FileNameExtension),
			   new SqlParameter("@msgFileNameDateFormat", item.FileNameDateFormat),
               new SqlParameter("@msgExcelTemplatePath", item.ExcelTemplatePath),
               new SqlParameter("@msgExcelRowOffset", item.ExcelRowOffset),
               new SqlParameter("@msgExcelXMLTableNo", item.ExcelXMLTableNo),
               new SqlParameter("@fileDirectionCode", item.FileDirectionCode),
               new SqlParameter("@applicationCode", item.ApplicationType),
               new SqlParameter("@user", item.User),
               new SqlParameter("@MsgMonday", item.MondayFlag),
               new SqlParameter("@MsgTuesday", item.TuesdayFlag),
               new SqlParameter("@MsgWednesday", item.WednesdayFlag),
               new SqlParameter("@MsgThursday", item.ThursdayFlag),
               new SqlParameter("@MsgFriday", item.FridayFlag),
               new SqlParameter("@MsgSaturday", item.SaturdayFlag),
               new SqlParameter("@MsgSunday", item.SundayFlag),
               new SqlParameter("@MsgManualRunFlag", item.ManualRunFlag),
               new SqlParameter("@MsgStartTime", item.StartRuntime),
               new SqlParameter("@MsgEndTime", item.EndRuntime),
               new SqlParameter("@MsgXmlNode", item.XmlNode),
               new SqlParameter("@IsUseTemporaryExtension", item.IsUseTemporaryExtension),
               new SqlParameter("@TemporaryExtension", item.TemporaryFileExtension),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(Messages item)
        {
            string query = "FT_MessagesUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@msgCode", item.MsgCode),
			   new SqlParameter("@trdpCode", item.TradingPartnercode),
			   new SqlParameter("@coluCode", item.ColuCode),
			   new SqlParameter("@msgIsDebug", item.IsDebug),
			   new SqlParameter("@msgCounter", item.Counter),
			   new SqlParameter("@msgName", item.Name),
			   new SqlParameter("@msgFileType", item.FileType),
			   new SqlParameter("@msgStartReadWrite", item.StartReadWrite),
			   new SqlParameter("@msgDelLinePattern", item.DelLinePattern),
			   new SqlParameter("@msgCodePage", item.CodePageId),
			   new SqlParameter("@msgFileNameConvention", item.FileNameConvention),
			   new SqlParameter("@msgFileNameExtension", item.FileNameExtension),
			   new SqlParameter("@msgFileNameDateFormat", item.FileNameDateFormat),
               new SqlParameter("@msgExcelTemplatePath", item.ExcelTemplatePath),
               new SqlParameter("@msgExcelRowOffset", item.ExcelRowOffset),
               new SqlParameter("@msgExcelXMLTableNo", item.ExcelXMLTableNo),
               new SqlParameter("@fileDirectionCode", item.FileDirectionCode),
               new SqlParameter("@applicationCode", item.ApplicationType),
               new SqlParameter("@user", item.User),
               new SqlParameter("@MsgMonday", item.MondayFlag),
               new SqlParameter("@MsgTuesday", item.TuesdayFlag),
               new SqlParameter("@MsgWednesday", item.WednesdayFlag),
               new SqlParameter("@MsgThursday", item.ThursdayFlag),
               new SqlParameter("@MsgFriday", item.FridayFlag),
               new SqlParameter("@MsgSaturday", item.SaturdayFlag),
               new SqlParameter("@MsgSunday", item.SundayFlag),
               new SqlParameter("@MsgManualRunFlag", item.ManualRunFlag),
               new SqlParameter("@MsgStartTime", item.StartRuntime),
               new SqlParameter("@MsgEndTime", item.EndRuntime),
               new SqlParameter("@MsgXmlNode", item.XmlNode),
               new SqlParameter("@IsUseTemporaryExtension", item.IsUseTemporaryExtension),
               new SqlParameter("@TemporaryExtension", item.TemporaryFileExtension),
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

        public int Delete(string msgCode, string trdpCode)
        {
            string query = "FT_MessagesDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@msgCode", msgCode),
               new SqlParameter("@trdpCode", trdpCode),
               sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }

        public List<Messages> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
