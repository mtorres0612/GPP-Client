using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDAL
{
    public class DateTypeDAL : IMaintainableDAL<DateType>
    {
        static DateTypeDAL _instance;

        public static DateTypeDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new DateTypeDAL();
            }
            return _instance;
        }

        public List<DateType> GetAll()
        {
            string query        = "FT_DateTypeSelProc";
            DataTable dt        = new DataTable();
            List<DateType> list = new List<DateType>();
            dt                  = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                DateType item     = new DateType();
                item.DateTypeCode = dr["DateTypeCode"].ToString();
                list.Add(item);
            }

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
