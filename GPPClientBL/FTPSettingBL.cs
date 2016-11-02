using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class FTPSettingBL : IMaintainableBL<FTPSetting>
    {
        static FTPSettingBL _instance;

        public static FTPSettingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FTPSettingBL();
            }
            return _instance;
        }

        FTPSettingDAL oFTPSettingDAL = FTPSettingDAL.GetInstance();

        public List<FTPSetting> GetAll(int fileTransferSettingId)
        {
            List<FTPSetting> list = new List<FTPSetting>();
            list = oFTPSettingDAL.GetAll(fileTransferSettingId);
            return list;
        }

        public List<FTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(FTPSetting item)
        {
            int result = 0;
            result     = oFTPSettingDAL.Insert(item);
            return result;
        }

        public int Update(FTPSetting item)
        {
            int result = 0;
            result     = oFTPSettingDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oFTPSettingDAL.Delete(id);
            return result;
        }
    }
}
