using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class FileEncodingBL : IMaintainableBL<FileEncoding>
    {
        static FileEncodingBL _instance;

        public static FileEncodingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileEncodingBL();
            }
            return _instance;
        }

        FileEncodingDAL oFileEncodingDAL = FileEncodingDAL.GetInstance();

        public List<FileEncoding> GetAll()
        {
            List<FileEncoding> list = new List<FileEncoding>();
            list                    = oFileEncodingDAL.GetAll();
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
