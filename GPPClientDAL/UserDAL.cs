using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPUtilities;
namespace GPPClientDAL
{
    public class UserDAL : IMaintainableDAL<User>
    {
        static UserDAL _instance;

        public static UserDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new UserDAL();
            }
            return _instance;
        }

        public List<User> GetAll(string userName, string password)
        {
            string query = "GetUser";
            DataTable dt = new DataTable();
            List<User> list = new List<User>();

            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@Username", userName),
               new SqlParameter("@Password", Utility.Encrypt(password)),
            };

            dt = GPPClientDB.GPPClientDB.GetData(query, sqlParams);

            foreach (DataRow dr in dt.Rows)
            {
                User item     = new User();
                item.ID       = Convert.ToInt32(dr["ID"].ToString());
                item.UserName = dr["Username"].ToString();
                item.Password = dr["Password"].ToString();
                item.Email    = dr["Email"].ToString();
                list.Add(item);
            }

            return list;
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(User item)
        {
            throw new NotImplementedException();
        }

        public int Update(User item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
