using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using GPPClientDAL;
namespace GPPClientBL
{
    public class FileDirectionBL : IMaintainableBL<FileDirection>
    {
        static FileDirectionBL _instance;

        public static FileDirectionBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileDirectionBL();
            }
            return _instance;
        }

        FileDirectionDAL oFileDirectionDAL = FileDirectionDAL.GetInstance(); 

        public List<FileDirection> GetAll()
        {
            List<FileDirection> list = new List<FileDirection>();
            list                     = oFileDirectionDAL.GetAll();

            return list;
        }

        public int Insert(FileDirection item)
        {
            int result = 0;
            result = oFileDirectionDAL.Insert(item);
            return result;
        }

        public int Update(FileDirection item)
        {
            int result = 0;
            result = oFileDirectionDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result = oFileDirectionDAL.Delete(id);
            return result;
        }
    }
}
