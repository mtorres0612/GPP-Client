using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class SMTPSettingBL : IMaintainableBL<SMTPSetting>
    {
        static SMTPSettingBL _instance;

        public static SMTPSettingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SMTPSettingBL();
            }
            return _instance;
        }

        SMTPSettingDAL oSMTPSettingDAL = SMTPSettingDAL.GetInstance();

        public List<SMTPSetting> GetAll(int fileTransferSettingId)
        {
            List<SMTPSetting> list = new List<SMTPSetting>();
            list                   = oSMTPSettingDAL.GetAll(fileTransferSettingId);
            return list;
        }

        public List<SMTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(SMTPSetting item)
        {
            throw new NotImplementedException();
        }

        public int Update(SMTPSetting item)
        {
            int result = 0;
            result     = oSMTPSettingDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
