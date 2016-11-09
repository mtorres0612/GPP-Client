using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class MessageSettingsBL : IMaintainableBL<MessageSettings>
    {
        static MessageSettingsBL _instance;

        public static MessageSettingsBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new MessageSettingsBL();
            }
            return _instance;
        }

        MessageSettingsDAL oMessageSettingsDAL = MessageSettingsDAL.GetInstance();

        public List<MessageSettings> GetAll(string msgCode)
        {
            List<MessageSettings> list = new List<MessageSettings>();
            list                       = oMessageSettingsDAL.GetAll(msgCode);
            return list;
        }

        public List<MessageSettings> GetAll()
        {
            throw new NotImplementedException();        
        }

        public int Insert(MessageSettings item)
        {
            int result = 0;
            result     = oMessageSettingsDAL.Insert(item);
            return result;
        }

        public int Update(MessageSettings item)
        {
            int result = 0;
            result = oMessageSettingsDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oMessageSettingsDAL.Delete(id);
            return result;
        }
    }
}
