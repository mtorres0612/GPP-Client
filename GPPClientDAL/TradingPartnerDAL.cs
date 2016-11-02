using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPUtilities;
using System.Data.SqlClient;
namespace GPPClientDAL
{
    public class TradingPartnerDAL : IMaintainableDAL<TradingPartner>
    {
        static TradingPartnerDAL _instance;

        public static TradingPartnerDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new TradingPartnerDAL();
            }
            return _instance;
        }

        public List<TradingPartner> GetAll()
        {
            string query              = "FT_TradingPartnerSelProc";
            DataTable dt              = new DataTable();
            List<TradingPartner> list = new List<TradingPartner>();
            dt                        = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                TradingPartner item     = new TradingPartner();
                item.Id                 = Convert.ToInt64(dr["ID"].ToString());
                item.TradingPartnerCode = dr["trdpCode"].ToString().Trim();
                item.Principal          = dr["PRNCPL"].ToString();
                item.Name               = dr["trdpName"].ToString();
                item.ColuCode           = dr["coluCode"].ToString();
                item.UserName           = dr["trdpUserName"].ToString();
                item.Password           = dr["trdpPassword"].ToString();

                if (DBNull.Value != dr["trdpXmlIdentityNode"])
                {
                    item.XmlIdentityNode = Convert.ToInt32(dr["trdpXmlIdentityNode"]);
                }
                else
                {
                    item.XmlIdentityNode = 0;
                }

                list.Add(item);
            }

            return list;
        }

        public int Insert(TradingPartner item)
        {
            string query = "FT_TradingPartnerInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =	
			{
				new SqlParameter("@trdpCode", item.TradingPartnerCode),
				new SqlParameter("@PRNCPL", item.Principal),
				new SqlParameter("@trdpName", item.Name),
				new SqlParameter("@coluCode", item.ColuCode),									
                new SqlParameter("@user", item.User),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password",  item.Password),
                new SqlParameter("@xmlIdentityNode",  item.XmlIdentityNode),
				sqlParamOutput
			};

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(TradingPartner item)
        {
            string query = "FT_TradingPartnerUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =	
			{
				new SqlParameter("@Id", item.Id),
				new SqlParameter("@trdpCode", item.TradingPartnerCode),
				new SqlParameter("@PRNCPL", item.Principal),
				new SqlParameter("@trdpName", item.Name),
				new SqlParameter("@coluCode", item.ColuCode),									
                new SqlParameter("@user", item.User),
                new SqlParameter("@username", item.UserName),
                new SqlParameter("@password",  item.Password),
                new SqlParameter("@xmlIdentityNode",  item.XmlIdentityNode),
				sqlParamOutput
			};

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_TradingPartnerDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@Id", Convert.ToInt64(id)),
               sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }

    }
}
