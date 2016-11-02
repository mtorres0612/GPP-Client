using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class MessagesBL : IMaintainableBL<Messages>
    {
        static MessagesBL _instance;

        public static MessagesBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new MessagesBL();
            }
            return _instance;
        }

        MessagesDAL oMessagesDAL = MessagesDAL.GetInstance();

        public List<Messages> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Messages> GetAllMessages(string trdpCode = "-1", string msgCode = "")
        {
            List<Messages> list = new List<Messages>();
            list = oMessagesDAL.GetAllMessages(trdpCode, msgCode);
            return list;
        }

        
        public int Insert(Messages item)
        {
            int result = 0;
            result = oMessagesDAL.Insert(item);
            return result;
        }

        public int Update(Messages item)
        {
            int result = 0;
            result = oMessagesDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }

        public int Delete(string msgCode, string trdpCode)
        {
            int result = 0;
            result = oMessagesDAL.Delete(msgCode, trdpCode);
            return result;
        }
    }
}
