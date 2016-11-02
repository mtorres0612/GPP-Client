using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientDAL
{
    public class CodePageDAL : IMaintainableDAL<CodePage>
    {
        static CodePageDAL _instance;

        public static CodePageDAL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new CodePageDAL();
            }
            return _instance;
        }

        public List<CodePage> GetAll()
        {
            string query        = "FT_CodePageSelProc";
            DataTable dt        = new DataTable();
            List<CodePage> list = new List<CodePage>();
            dt                  = GPPClientDB.GPPClientDB.GetData(query);

            foreach (DataRow dr in dt.Rows)
            {
                CodePage item     = new CodePage();
                item.CodePageId   = Convert.ToInt32(dr["MsgCodePage"].ToString());
                item.CodePageName = dr["MsgCodePageName"].ToString();
                list.Add(item);
            }

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
