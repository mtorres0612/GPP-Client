using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using System.Data;
using System.Data.SqlClient;
namespace GPPClientDAL
{
    public class EmailDistributionListDAL : IMaintainableDAL<EmailDistributionList>
    {
        static EmailDistributionListDAL _instance;

        public static EmailDistributionListDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new EmailDistributionListDAL();
            }
            return _instance;
        }

        public List<EmailDistributionList> GetAll()
        {
            string query                     = "FT_EmailDistributionListSelProc";
            DataTable dt                     = new DataTable();
            List<EmailDistributionList> list = new List<EmailDistributionList>();
            SqlParameter[] sqlParams         =  
            {
               new SqlParameter("@msgcode", string.Empty),
			   new SqlParameter("@erp", string.Empty) 
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                EmailDistributionList item = new EmailDistributionList();
                item.Emldkey               = Convert.ToInt32(dr["emldKey"]);
                item.MsgCode               = dr["MsgCode"].ToString();
                item.ERP                   = dr["Erp"].ToString();
                item.EmailSubject          = dr["emldEmailSubject"].ToString();
                item.EmailAddrFrom         = dr["emldIntEmailAddrFROM"].ToString();
                item.EmailAddrTo           = dr["emldIntEmailAddrTO"].ToString();
                item.EmailAddrCC           = dr["emldIntEmailAddrCC"].ToString();
                item.EmailAddrBCC          = dr["emldIntEmailAddrBCC"].ToString();
                item.ExtEmailAddrTo        = dr["emldExtEmailAddrTO"].ToString();
                item.ExtEmailAddrCC        = dr["emldExtEmailAddrCC"].ToString();
                item.XsltPath              = dr["emldXSLTPath"].ToString();

                if (dr["emldLastEmailDate"] != DBNull.Value)
                {
                    item.LastEmailDate = Convert.ToDateTime(dr["emldLastEmailDate"]);
                    item.LastEmailShortDate = item.LastEmailDate.Value.ToShortDateString();
                }
                else
                {
                    item.LastEmailDate = null;
                    item.LastEmailShortDate = string.Empty;
                }


                list.Add(item);
            }

            return list;
        }

        public int Insert(EmailDistributionList item)
        {
            string query = "FT_EmailDistributionListInsProc";
            int result = 0;

            object tempLastEmailDate = DBNull.Value;
            if (item.LastEmailDate != null)
                tempLastEmailDate = item.LastEmailDate;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@msgCode", item.MsgCode),
			   new SqlParameter("@ERP", item.ERP),
			   new SqlParameter("@emldEmailSubject", item.EmailSubject),
			   new SqlParameter("@emldIntEmailAddrFROM", item.EmailAddrFrom),
			   new SqlParameter("@emldIntEmailAddrTO", item.EmailAddrTo),
			   new SqlParameter("@emldIntEmailAddrCC", item.EmailAddrCC),
			   new SqlParameter("@emldIntEmailAddrBCC", item.EmailAddrBCC),
			   new SqlParameter("@emldExtEmailAddrTO", item.ExtEmailAddrTo),
			   new SqlParameter("@emldExtEmailAddrCC", item.ExtEmailAddrCC),
			   new SqlParameter("@emldXSLTPath", item.XsltPath),                                    
               new SqlParameter("@emldLastEmailDate", tempLastEmailDate),                                    
			   new SqlParameter("@user", item.User),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(EmailDistributionList item)
        {
            string query = "FT_EmailDistributionListUpdProc";
            int result = 0;
            item.LastEmailDate = Convert.ToDateTime(item.LastEmailShortDate);
            object tempLastEmailDate = DBNull.Value;
            if (item.LastEmailDate != null)
                tempLastEmailDate = item.LastEmailDate;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@emldKey", item.Emldkey),
               new SqlParameter("@msgCode", item.MsgCode),
			   new SqlParameter("@ERP", item.ERP),
			   new SqlParameter("@emldEmailSubject", item.EmailSubject),
			   new SqlParameter("@emldIntEmailAddrFROM", item.EmailAddrFrom),
			   new SqlParameter("@emldIntEmailAddrTO", item.EmailAddrTo),
			   new SqlParameter("@emldIntEmailAddrCC", item.EmailAddrCC),
			   new SqlParameter("@emldIntEmailAddrBCC", item.EmailAddrBCC),
			   new SqlParameter("@emldExtEmailAddrTO", item.ExtEmailAddrTo),
			   new SqlParameter("@emldExtEmailAddrCC", item.ExtEmailAddrCC),
			   new SqlParameter("@emldXSLTPath", item.XsltPath),                                    
               new SqlParameter("@emldLastEmailDate", tempLastEmailDate),                                    
			   new SqlParameter("@user", item.User),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            var outputParam = sqlParamOutput.Value;

            if (!(outputParam is DBNull))
            {
                result = Convert.ToInt32(outputParam);
            }

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_EmailDistributionListDelProcc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@emldKey", Convert.ToInt32(id)),
               sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
