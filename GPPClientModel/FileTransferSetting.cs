using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class FileTransferSetting : BaseModel
    {
        private int? _fileTransferSettingID;

        public int? FileTransferSettingID
        {
            get { return _fileTransferSettingID; }
            set { _fileTransferSettingID = value; }
        }

        private int? _transmissionTypeID;

        [Display(Name = "Transmission Type")]
        public int? TransmissionTypeID
        {
            get { return _transmissionTypeID; }
            set { _transmissionTypeID = value; }
        }

        private string _msgCode;

        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = value; }
        }

    }
}
