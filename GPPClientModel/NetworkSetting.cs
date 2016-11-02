using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class NetworkSetting : BaseModel
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

        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private int _messageFileID;

        public int MessageFileID
        {
            get { return _messageFileID; }
            set { _messageFileID = value; }
        }

        private string _username;

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }



    }
}
