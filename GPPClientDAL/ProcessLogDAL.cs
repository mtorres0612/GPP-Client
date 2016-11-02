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
    public class ProcessLogDAL : IMaintainableDAL<ProcessLog>
    {
        static ProcessLogDAL _instance;

        public static ProcessLogDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ProcessLogDAL();
            }
            return _instance;
        }

        public List<ProcessLog> GetAll(DateTime? startDate, DateTime? endDate, string erp, string status, string msgCode, string applicationCode)
        {
            string query          = "FT_ProcessLogSelProc";
            DataTable dt          = new DataTable();
            List<ProcessLog> list = new List<ProcessLog>();
            object objstartDate   = DBNull.Value;
            object objendDate     = DBNull.Value;

            if (startDate != null) objstartDate = startDate.Value.Date;
            if (endDate != null) objendDate = endDate.Value.Date;

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@startDate", objstartDate),
               new SqlParameter("@endDate", objendDate),
               new SqlParameter("@ERP", erp),
               new SqlParameter("@Status", status.ToUpper()),                                            
               new SqlParameter("@msgCode", msgCode),
               new SqlParameter("@aplucode", applicationCode)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                ProcessLog item    = new ProcessLog();
                item.Id            = Convert.ToInt32(dr["prlgID"].ToString());
                item.MsgCode       = dr["MsgCode"].ToString();
                item.ProcessSource = dr["prlgProcessSource"].ToString();
                item.Description   = dr["prlgDescription"].ToString();
                item.TechErrDesc   = dr["prlgTechnicalErrDesc"].ToString();
                item.StartDate     = Convert.ToDateTime(dr["prlgStartDate"]);
                item.EndDate       = Convert.ToDateTime(dr["prlgEndDate"]);

                list.Add(item);
            }

            return list;
        }

        public List<ProcessLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(ProcessLog item)
        {
            throw new NotImplementedException();
        }

        public int Update(ProcessLog item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
