using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class FileTransferSettingBL : IMaintainableBL<FileTransferSetting>
    {
        static FileTransferSettingBL _instance;

        public static FileTransferSettingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FileTransferSettingBL();
            }
            return _instance;
        }

        FileTransferSettingDAL oFileTransferSettingDAL = FileTransferSettingDAL.GetInstance();

        public List<FileTransferSetting> GetAll(int fileTransferSettingId)
        {
            List<FileTransferSetting> list = new List<FileTransferSetting>();
            list                           = oFileTransferSettingDAL.GetAll(fileTransferSettingId);
            return list;
        }

        public List<FileTransferSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(FileTransferSetting item)
        {
            int result = 0;
            result     = oFileTransferSettingDAL.Insert(item);
            return result;
        }

        public int Update(FileTransferSetting item)
        {
            int result = 0;
            result     = oFileTransferSettingDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oFileTransferSettingDAL.Delete(id);
            return result;
        }
    }
}
