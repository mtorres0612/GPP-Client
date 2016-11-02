using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using GPPClientDAL;
namespace GPPClientBL
{
    public class EmailDistributionListBL : IMaintainableBL<EmailDistributionList>
    {
        static EmailDistributionListBL _instance;

        public static EmailDistributionListBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new EmailDistributionListBL();
            }
            return _instance;
        }

        EmailDistributionListDAL oEmailDistributionListDAL = EmailDistributionListDAL.GetInstance(); 

        public List<EmailDistributionList> GetAll()
        {
            List<EmailDistributionList> list = new List<EmailDistributionList>();
            list                             = oEmailDistributionListDAL.GetAll();
            return list;
        }

        public int Insert(EmailDistributionList item)
        {
            int result = 0;
            result = oEmailDistributionListDAL.Insert(item);
            return result;
        }

        public int Update(EmailDistributionList item)
        {
            int result = 0;
            result = oEmailDistributionListDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result = 0;
            result = oEmailDistributionListDAL.Delete(id);
            return result;
        }
    }
}
