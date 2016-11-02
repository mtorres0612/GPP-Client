using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDAL
{
    public class ApplicationCodeDAL : IMaintainableDAL<ApplicationCode>
    {
        static ApplicationCodeDAL _instance;

        public static ApplicationCodeDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ApplicationCodeDAL();
            }
            return _instance;
        }

        public List<ApplicationCode> GetAll()
        {
            string query               = "FT_ApplicationCodeSelProc";
            DataTable dt               = new DataTable();
            List<ApplicationCode> list = new List<ApplicationCode>();
            dt                         = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                ApplicationCode item = new ApplicationCode();
                item.Code            = dr["apluCode"].ToString();
                item.Name            = dr["apluName"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(ApplicationCode item)
        {
            throw new NotImplementedException();
        }

        public int Update(ApplicationCode item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
