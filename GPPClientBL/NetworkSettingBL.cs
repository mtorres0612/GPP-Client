using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class NetworkSettingBL : IMaintainableBL<NetworkSetting>
    {
        static NetworkSettingBL _instance;

        public static NetworkSettingBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new NetworkSettingBL();
            }
            return _instance;
        }

        NetworkSettingDAL oNetworkSettingDAL = NetworkSettingDAL.GetInstance();

        public List<NetworkSetting> GetAll(int fileTransferSettingId)
        {
            List<NetworkSetting> list = new List<NetworkSetting>();
            list                      = oNetworkSettingDAL.GetAll(fileTransferSettingId);
            return list;
        }

        public List<NetworkSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(NetworkSetting item)
        {
            throw new NotImplementedException();
        }

        public int Update(NetworkSetting item)
        {
            int result = 0;
            result     = oNetworkSettingDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oNetworkSettingDAL.Delete(id);
            return result;
        }
    }
}
