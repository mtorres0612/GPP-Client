using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class ApplicationCodeBL : IMaintainableBL<ApplicationCode>
    {
        static ApplicationCodeBL _instance;

        public static ApplicationCodeBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ApplicationCodeBL();
            }
            return _instance;
        }

        ApplicationCodeDAL oApplicationCodeDAL = ApplicationCodeDAL.GetInstance();

        public List<ApplicationCode> GetAll()
        {
            List<ApplicationCode> list = new List<ApplicationCode>();
            list = oApplicationCodeDAL.GetAll();
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
