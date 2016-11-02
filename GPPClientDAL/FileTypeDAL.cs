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
    public class FileTypeDAL : IMaintainableDAL<FileType>
    {
        static FileTypeDAL _instance;

        public static FileTypeDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileTypeDAL();
            }
            return _instance;
        }

        public List<FileType> GetAll()
        {
            string query        = "FT_FileTypeSelProc";
            DataTable dt        = new DataTable();
            List<FileType> list = new List<FileType>();
            dt                  = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                FileType item = new FileType();
                item.FileTypeCode = dr["FileTypeCode"].ToString();
                item.FileTypeName = dr["FileTypeName"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(FileType item)
        {
            string query = "FT_FileTypeInsProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileTypeCode", item.FileTypeCode),
			   new SqlParameter("@fileTypeName", item.FileTypeName), 
               sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Update(FileType item)
        {
            string query = "FT_FileTypeUpdProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
               new SqlParameter("@fileTypeCode", item.FileTypeCode),
			   new SqlParameter("@fileTypeName", item.FileTypeName), 
                sqlParamOutput
            };

            GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            result = Convert.ToInt32(sqlParamOutput.Value);

            return result;
        }

        public int Delete(object id)
        {
            string query = "FT_FileTypeDelProc";
            int result = 0;

            SqlParameter sqlParamOutput = new SqlParameter("@returnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter[] sqlParams =  
            {
                new SqlParameter("@fileTypeCode", Convert.ToString(id)),
                sqlParamOutput
            };

            result = GPPClientDB.GPPClientDB.ExecuteNonQuery(query, sqlParams);

            return result;
        }
    }
}
