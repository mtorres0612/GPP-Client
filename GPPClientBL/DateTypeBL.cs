using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class DateTypeBL : IMaintainableBL<DateType>
    {
        static DateTypeBL _instance;

        public static DateTypeBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new DateTypeBL();
            }
            return _instance;
        }

        DateTypeDAL oDateTypeDAL = DateTypeDAL.GetInstance();

        public List<DateType> GetAll()
        {
            List<DateType> list = new List<DateType>();
            list                = oDateTypeDAL.GetAll();
            return list;
        }

        public int Insert(DateType item)
        {
            throw new NotImplementedException();
        }

        public int Update(DateType item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
