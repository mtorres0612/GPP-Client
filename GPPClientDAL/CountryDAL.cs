using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDAL
{
    public class CountryDAL
    {
        static CountryDAL _instance;

        public static CountryDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new CountryDAL();
            }
            return _instance;
        }

        public List<Country> GetAll()
        {
            string query       = "FT_CountrySelProc";
            DataTable dt       = new DataTable();
            List<Country> list = new List<Country>();
            dt                 = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                Country item = new Country();
                item.Code = dr["coluCode"].ToString();
                item.Name = dr["coluName"].ToString();
                list.Add(item);
            }

            return list;
        }
    }
}
