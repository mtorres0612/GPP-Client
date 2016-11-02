using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientDAL;
using GPPClientModel;
namespace GPPClientBL
{
    public class TransmissionTypeBL : IMaintainableBL<TransmissionType>
    {
        static TransmissionTypeBL _instance;

        public static TransmissionTypeBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new TransmissionTypeBL();
            }
            return _instance;
        }

        TransmissionTypeDAL oTransmissionTypeDAL = TransmissionTypeDAL.GetInstance();  

        public List<TransmissionType> GetAll()
        {
            List<TransmissionType> list = new List<TransmissionType>();
            list                        = oTransmissionTypeDAL.GetAll();

            return list;
        }

        public int Insert(TransmissionType item)
        {
            int result   = 0;
            result       = oTransmissionTypeDAL.Insert(item);
            return result;
        }

        public int Update(TransmissionType item)
        {
            int result = 0;
            result     = oTransmissionTypeDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result     = oTransmissionTypeDAL.Delete(id);
            return result;
        }
    }
}
