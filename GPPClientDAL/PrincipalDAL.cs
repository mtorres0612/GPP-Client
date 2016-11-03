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
    public class PrincipalDAL : IMaintainableDAL<Principal>
    {
        static PrincipalDAL _instance;

        public static PrincipalDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new PrincipalDAL();
            }
            return _instance;
        }

        public List<Principal> GetAll(string erp)
        {
            string query         = "FT_PrincipalSelProc";
            DataTable dt         = new DataTable();
            List<Principal> list = new List<Principal>();

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@erp", erp)
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                Principal item = new Principal();
                item.PRNCPL    = dr["PRNCPL"].ToString();
                item.Name      = dr["PMName"].ToString();
                list.Add(item);
            }

            Principal defaultItem = new Principal();
            defaultItem.PRNCPL    = "IMS";
            defaultItem.Display   = "IMS";
            list.Add(defaultItem);

            return list;
        }

        public List<Principal> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Principal item)
        {
            throw new NotImplementedException();
        }

        public int Update(Principal item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
