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
    public class SourceFileLogDAL : IMaintainableDAL<SourceFileLog>
    {
        static SourceFileLogDAL _instance;

        public static SourceFileLogDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SourceFileLogDAL();
            }
            return _instance;
        }

        public List<SourceFileLog> GetAll(string directionCode, DateTime? startDate, DateTime? endDate, string erp, string status, string trdpCode, string msgCode, string aplucode)
        {
            string query             = "FT_SourceFileLogSelProc";
            DataTable dt             = new DataTable();
            List<SourceFileLog> list = new List<SourceFileLog>();
            object objstartDate      = DBNull.Value;
            object objendDate        = DBNull.Value;

            if (startDate != null) objstartDate = startDate.Value.Date;
            if (endDate != null) objendDate = endDate.Value.Date;

            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@directionCode", directionCode), 
                new SqlParameter("@startDate", objstartDate),
                new SqlParameter("@endDate", objendDate),
                new SqlParameter("@ERP", erp),
                new SqlParameter("@Status", status),
                new SqlParameter("@trdpCode", trdpCode),
                new SqlParameter("@msgCode", msgCode),
                new SqlParameter("@aplucode", aplucode)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                SourceFileLog item       = new SourceFileLog();
                item.SflgID              = Convert.ToInt32(dr["sflgID"]);
                item.Status              = dr["sflgStatus"].ToString();
                item.TrdpCode            = dr["trdpCode"].ToString();
                item.MsgCode             = dr["msgCode"].ToString();
                item.ERP                 = dr["ERP"].ToString();
                item.IsCountrySetup      = Convert.ToBoolean(dr["sflgIsCountrySetup"]);
                item.FileType            = dr["sflgFileType"].ToString();
                item.SourceFilename      = dr["sflgSourceFilename"].ToString();
                item.DestinationFilename = dr["sflgDestinationFilename"].ToString();
                item.InterchangeNo       = dr["sflgInterchangeNo"].ToString();
                item.DocumentNo          = dr["sflgDocumentNo"].ToString();
                item.FileDirectionCode   = dr["fileDirectionCode"].ToString();
                item.ProcessDate         = Convert.ToDateTime(dr["sflgAddDate"]);

                list.Add(item);
            }

            return list;
        }

        public List<SourceFileLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(SourceFileLog item)
        {
            throw new NotImplementedException();
        }

        public int Update(SourceFileLog item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
