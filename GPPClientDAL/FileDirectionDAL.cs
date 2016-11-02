using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using System.Data;
using System.Data.SqlClient;
namespace GPPClientDAL
{
    public class FileDirectionDAL : IMaintainableDAL<FileDirection>
    {
        static FileDirectionDAL _instance;

        public static FileDirectionDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileDirectionDAL();
            }
            return _instance;
        }

        public List<FileDirection> GetAll()
        {
            string query = "FT_FileDirectionSelProc";
            DataTable dt = new DataTable();
            List<FileDirection> list = new List<FileDirection>();
            dt = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                FileDirection item     = new FileDirection();
                item.FileDirectionCode = dr["FileDirectionCode"].ToString();
                item.FileDirectionName = dr["FileDirectionName"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(FileDirection item)
        {
            string query = "FT_FileDirectionInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileDirectionCode", item.FileDirectionCode),
			   new SqlParameter("@fileDirectionName", item.FileDirectionName),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(FileDirection item)
        {
            string query = "FT_FileDirectionUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileDirectionCode", item.FileDirectionCode),
               new SqlParameter("@fileDirectionName", item.FileDirectionName),
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_FileDirectionDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileDirectionCode", Convert.ToString(id)),
               sqlParamOutput
            };


            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
