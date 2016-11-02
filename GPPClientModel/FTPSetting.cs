using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class FTPSetting : BaseModel
    {
        private int _portNumber;
        private int _idNo;
        private int _fileTransferSettingID;
        private string _ipAddress;
        private string _folder;
        private string _username;
        private string _password;

        public int PortNumber
        {
            get { return _portNumber; }
            set { _portNumber = value; }
        }

        public int IDNo
        {
            get { return _idNo; }
            set { _idNo = value; }
        }

        public int FileTransferSettingID
        {
            get { return _fileTransferSettingID; }
            set { _fileTransferSettingID = value; }
        }

        public string IPAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        public string Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

    }
}
