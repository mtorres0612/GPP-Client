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
            string query = "FT_UserSelProc";
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
                User item       = new User();
                item.ID         = Convert.ToInt32(dr["ID"].ToString());
                item.LastName   = dr["LastName"].ToString();
                item.FirstName  = dr["FirstName"].ToString();
                item.MiddleName = dr["MiddleName"].ToString();
                item.Address    = dr["Address"].ToString();
                item.Phone      = dr["Phone"].ToString();
                item.Email      = dr["Email"].ToString();
                item.UserName   = dr["Username"].ToString();
                item.Password   = Utility.Decrypt(dr["Password"].ToString());
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
            string query = "FT_UserInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@LastName", item.LastName),
			   new SqlParameter("@FirstName", item.FirstName),
			   new SqlParameter("@MiddleName", item.MiddleName),
			   new SqlParameter("@Address", item.Address),
			   new SqlParameter("@Phone", item.Phone),
			   new SqlParameter("@Email", item.Email),
			   new SqlParameter("@Username", item.UserName),
			   new SqlParameter("@Password", Utility.Encrypt(item.Password)),
			   new SqlParameter("@RegDate", DateTime.Now),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(User item)
        {
            string query = "FT_UserUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@ID", item.ID),
               new SqlParameter("@LastName", item.LastName),
			   new SqlParameter("@FirstName", item.FirstName),
			   new SqlParameter("@MiddleName", item.MiddleName),
			   new SqlParameter("@Address", item.Address),
			   new SqlParameter("@Phone", item.Phone),
			   new SqlParameter("@Email", item.Email),
			   new SqlParameter("@Username", item.UserName),
			   new SqlParameter("@Password", Utility.Encrypt(item.Password)),
			   new SqlParameter("@ModifiedDate", DateTime.Now),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_UserDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@ID", Convert.ToString(id)),
               sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
