using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class CodePage : BaseModel
    {
        private int _codePageId;

        public int CodePageId
        {
            get { return _codePageId; }
            set { _codePageId = value; }
        }

        private string _codePageName;

        public string CodePageName
        {
            get { return _codePageName; }
            set { _codePageName = value; }
        }

    }
}
