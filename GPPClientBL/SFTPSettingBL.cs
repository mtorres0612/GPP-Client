using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class SFTPSettingBL : IMaintainableBL<SFTPSetting>
    {
        static SFTPSettingBL _instance;

        public static SFTPSettingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SFTPSettingBL();
            }
            return _instance;
        }

        SFTPSettingDAL oSFTPSettingDAL = SFTPSettingDAL.GetInstance();

        public List<SFTPSetting> GetAll(int fileTransferSettingId)
        {
            List<SFTPSetting> list = new List<SFTPSetting>();
            list                   = oSFTPSettingDAL.GetAll(fileTransferSettingId);
            return list;
        }

        public List<SFTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(SFTPSetting item)
        {
            int result = 0;
            result     = oSFTPSettingDAL.Insert(item);
            return result;
        }

        public int Update(SFTPSetting item)
        {
            int result = 0;
            result     = oSFTPSettingDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oSFTPSettingDAL.Delete(id);
            return result;
        }
    }
}
