using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class FileEncoding : BaseModel
    {
        private int _codePageNum;

        public int CodePageNum
        {
            get { return _codePageNum; }
            set { _codePageNum = value; }
        }

        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
}
