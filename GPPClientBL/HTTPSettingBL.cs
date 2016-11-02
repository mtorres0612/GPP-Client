using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class HTTPSettingBL : IMaintainableBL<HTTPSetting>
    {
        static HTTPSettingBL _instance;

        public static HTTPSettingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new HTTPSettingBL();
            }
            return _instance;
        }

        HTTPSettingDAL oHTTPSettingDAL = HTTPSettingDAL.GetInstance();

        public List<HTTPSetting> GetAll(int fileTransferSettingId)
        {
            List<HTTPSetting> list = new List<HTTPSetting>();
            list                   = oHTTPSettingDAL.GetAll(fileTransferSettingId);
            return list;
        }

        public List<HTTPSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(HTTPSetting item)
        {
            int result = 0;
            result     = oHTTPSettingDAL.Insert(item);
            return result;
        }

        public int Update(HTTPSetting item)
        {
            int result = 0;
            result     = oHTTPSettingDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oHTTPSettingDAL.Delete(id);
            return result;
        }
    }
}
