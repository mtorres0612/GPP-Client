using GPPClientDAL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public class CodePageBL : IMaintainableBL<CodePage>
    {
        static CodePageBL _instance;

        public static CodePageBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new CodePageBL();
            }
            return _instance;
        }

        CodePageDAL oCodePageDAL = CodePageDAL.GetInstance();

        public List<CodePage> GetAll()
        {
            List<CodePage> list = new List<CodePage>();
            list = oCodePageDAL.GetAll();
            return list;
        }

        public int Insert(CodePage item)
        {
            throw new NotImplementedException();
        }

        public int Update(CodePage item)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
