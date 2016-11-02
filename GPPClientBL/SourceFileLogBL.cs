using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class SourceFileLogBL : IMaintainableBL<SourceFileLog>
    {
        static SourceFileLogBL _instance;

        public static SourceFileLogBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SourceFileLogBL();
            }
            return _instance;
        }

        SourceFileLogDAL oSourceFileLogDAL = SourceFileLogDAL.GetInstance();

        public List<SourceFileLog> GetAll(string directionCode, DateTime? startDate, DateTime? endDate, string erp, string status, string trdpCode, string msgCode, string aplucode)
        {
            List<SourceFileLog> list = new List<SourceFileLog>();
            list                     = oSourceFileLogDAL.GetAll(directionCode, startDate, endDate, erp, status, trdpCode, msgCode, aplucode);
            return list;
        }

        public List<SourceFileLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(SourceFileLog item)
        {
            throw new NotImplementedException();
        }

        public int Update(SourceFileLog item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
