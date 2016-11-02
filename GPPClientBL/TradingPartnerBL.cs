using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class TradingPartnerBL : IMaintainableBL<TradingPartner>
    {
        static TradingPartnerBL _instance;

        public static TradingPartnerBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new TradingPartnerBL();
            }
            return _instance;
        }

        TradingPartnerDAL oTradingPartnerDAL = TradingPartnerDAL.GetInstance();

        public List<TradingPartner> GetAll()
        {
            List<TradingPartner> list = new List<TradingPartner>();
            list = oTradingPartnerDAL.GetAll();
            return list;
        }

        public int Insert(TradingPartner item)
        {
            int result = 0;
            result     = oTradingPartnerDAL.Insert(item);
            return result;
        }

        public int Update(TradingPartner item)
        {
            int result = 0;
            result     = oTradingPartnerDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result = oTradingPartnerDAL.Delete(id);
            return result;
        }
    }
}
