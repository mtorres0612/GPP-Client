using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDAL
{
    public class FileEncodingDAL : IMaintainableDAL<FileEncoding>
    {
        static FileEncodingDAL _instance;

        public static FileEncodingDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileEncodingDAL();
            }
            return _instance;
        }

        public List<FileEncoding> GetAll()
        {
            string query            = "GetEncodingFormats";
            DataTable dt            = new DataTable();
            List<FileEncoding> list = new List<FileEncoding>();
            dt                      = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                FileEncoding item = new FileEncoding();
                item.CodePageNum  = Convert.ToInt32(dr["FELUCodePage"].ToString());
                item.DisplayName  = dr["FELUDescription"].ToString();
                list.Add(item);
            }

            return list;
        }

        public int Insert(FileEncoding item)
        {
            throw new NotImplementedException();
        }

        public int Update(FileEncoding item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
