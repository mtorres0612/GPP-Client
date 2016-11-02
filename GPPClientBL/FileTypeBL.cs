using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using GPPClientDAL;
namespace GPPClientBL
{
    public class FileTypeBL : IMaintainableBL<FileType>
    {
        static FileTypeBL _instance;

        public static FileTypeBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileTypeBL();
            }
            return _instance;
        }

        FileTypeDAL oFileTypeDAL = FileTypeDAL.GetInstance(); 

        public List<FileType> GetAll()
        {
            List<FileType> list      = new List<FileType>();
            list                     = oFileTypeDAL.GetAll();

            return list;
        }

        public int Insert(FileType item)
        {
            int result               = 0;
            result                   = oFileTypeDAL.Insert(item);
            return result;
        }

        public int Update(FileType item)
        {
            int result               = 0;
            result                   = oFileTypeDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result               = 0;
            result                   = oFileTypeDAL.Delete(id);
            return result;
        }
    }
}
