using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class HTTPSetting : BaseModel
    {
        private int _idNo;

        public int IDNo
        {
            get { return _idNo; }
            set { _idNo = value; }
        }

        private int _fileTransferSettingID;

        public int FileTransferSettingID
        {
            get { return _fileTransferSettingID; }
            set { _fileTransferSettingID = value; }
        }

        private string _url;

        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
