using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class SourceFileLog : BaseModel
    {
        private DateTime _processDate;
        private int _sflgID;
        private string _status;
        private string _trdpCode;
        private string _msgCode;
        private string _erp;
        private bool _isCountrySetup;
        private string _fileType;
        private string _sourceFilename;
        private string _destinationFilename;
        private string _interchangeNo;
        private string _documentNo;
        private string _fileDirectionCode;
        private string _user;

        public DateTime ProcessDate
        {
            get { return _processDate; }
            set { _processDate = value; }
        }

        public int SflgID
        {
            get { return _sflgID; }
            set { _sflgID = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string TrdpCode
        {
            get { return _trdpCode; }
            set { _trdpCode = value; }
        }

        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = value; }
        }

        public string ERP
        {
            get { return _erp; }
            set { _erp = value; }
        }

        public bool IsCountrySetup
        {
            get { return _isCountrySetup; }
            set { _isCountrySetup = value; }
        }

        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        public string SourceFilename
        {
            get { return _sourceFilename; }
            set { _sourceFilename = value; }
        }

        public string DestinationFilename
        {
            get { return _destinationFilename; }
            set { _destinationFilename = value; }
        }

        public string InterchangeNo
        {
            get { return _interchangeNo; }
            set { _interchangeNo = value; }
        }

        public string DocumentNo
        {
            get { return _documentNo; }
            set { _documentNo = value; }
        }

        public string FileDirectionCode
        {
            get { return _fileDirectionCode; }
            set { _fileDirectionCode = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

    }
}
