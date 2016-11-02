using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientDAL;
namespace GPPClientBL
{
    public class CountryBL
    {
        static CountryBL _instance;

        public static CountryBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new CountryBL();
            }
            return _instance;
        }

        CountryDAL oCountryDAL = CountryDAL.GetInstance(); 

        public List<Country> GetAll()
        {
            List<Country> list     = new List<Country>();
            list                   = oCountryDAL.GetAll();

            return list;
        }
    }
}
