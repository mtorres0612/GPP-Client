using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class UserBL : IMaintainableBL<User>
    {
        static UserBL _instance;

        public static UserBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new UserBL();
            }
            return _instance;
        }

        UserDAL oUserDAL = UserDAL.GetInstance();

        public List<User> GetAll(string userName, string password)
        {
            List<User> list = new List<User>();
            list            = oUserDAL.GetAll(userName, password);
            return list;
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(User item)
        {
            int result = 0;
            result     = oUserDAL.Insert(item);
            return result;
        }

        public int Update(User item)
        {
            int result = 0;
            result     = oUserDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oUserDAL.Delete(id);
            return result;
        }
    }
}
