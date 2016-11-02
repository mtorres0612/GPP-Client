using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class ProcessLogBL : IMaintainableBL<ProcessLog>
    {
        static ProcessLogBL _instance;

        public static ProcessLogBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ProcessLogBL();
            }
            return _instance;
        }

        ProcessLogDAL oProcessLogDAL = ProcessLogDAL.GetInstance();

        public List<ProcessLog> GetAll(DateTime? startDate, DateTime? endDate, string erp, string status, string msgCode, string applicationCode)
        {
            List<ProcessLog> list = new List<ProcessLog>();
            list                  = oProcessLogDAL.GetAll(startDate, endDate, erp, status, msgCode, applicationCode);
            return list;
        }

        public List<ProcessLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(ProcessLog item)
        {
            throw new NotImplementedException();
        }

        public int Update(ProcessLog item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
