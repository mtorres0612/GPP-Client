using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class PrincipalBL : IMaintainableBL<Principal>
    {
        static PrincipalBL _instance;

        public static PrincipalBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new PrincipalBL();
            }
            return _instance;
        }

        PrincipalDAL oPrincipalDAL = PrincipalDAL.GetInstance();

        public List<Principal> GetAll(string erp)
        {
            List<Principal> list = new List<Principal>();
            list                 = oPrincipalDAL.GetAll(erp);
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
