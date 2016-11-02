using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientDAL;
using GPPClientModel;
namespace GPPClientBL
{
    public class ERPBL : IMaintainableBL<ERP>
    {
        static ERPBL _instance;

        public static ERPBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ERPBL();
            }
            return _instance;
        }

        ERPDAL oERPDAL = ERPDAL.GetInstance(); 

        public List<ERP> GetAll()
        {
            List<ERP> list = new List<ERP>();
            list           = oERPDAL.GetAll();
            return list;
        }

        public int Insert(ERP item)
        {
            int result = 0;
            result = oERPDAL.Insert(item);
            return result;
        }

        public int Update(ERP item)
        {
            int result = 0;
            result = oERPDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result = oERPDAL.Delete(id);
            return result;
        }
    }
}
